const API = {
    base: '/api',

    async _request(method, url, body = null) {
        const opts = {
            method,
            headers: { 'Content-Type': 'application/json' },
            credentials: 'same-origin'
        };
        if (body) opts.body = JSON.stringify(body);
        const res = await fetch(this.base + url, opts);
        const data = await res.json();
        if ('signal' in data) {
            if (!data.signal) throw new Error(data.poruka || 'Greška');
            return data.podaci ?? data;
        }
        return data;
    },

    async login(username, password) {
        const res = await fetch('/api/auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            credentials: 'same-origin',
            body: JSON.stringify({ username, password })
        });
        const data = await res.json();
        if (!data.signal) throw new Error(data.poruka || 'Neispravni kredencijali.');
        sessionStorage.setItem('ulogovan', 'true');
        sessionStorage.setItem('ime', (data.podaci?.ime || '') + ' ' + (data.podaci?.prezime || ''));
        return data.podaci;
    },

    async logout() {
        sessionStorage.clear();
        return this._request('POST', '/auth/logout');
    },

    async authStatus() {
        const res = await fetch('/api/auth/status', { credentials: 'same-origin' });
        return res.json();
    },

    async getKnjige(q = '') {
        return this._request('GET', `/knjiga${q ? '?q=' + encodeURIComponent(q) : ''}`);
    },
    async addKnjiga(k) { return this._request('POST', '/knjiga', k); },
    async updateKnjiga(id, k) { return this._request('PUT', `/knjiga/${id}`, k); },
    async deleteKnjiga(id) { return this._request('DELETE', `/knjiga/${id}`); },

    async getClanovi(q = '') {
        return this._request('GET', `/clan${q ? '?q=' + encodeURIComponent(q) : ''}`);
    },
    async getClanstva() { return this._request('GET', '/clan/clanstva'); },
    async addClan(c) { return this._request('POST', '/clan', c); },
    async updateClan(id, c) { return this._request('PUT', `/clan/${id}`, c); },
    async deleteClan(id) { return this._request('DELETE', `/clan/${id}`); },

    async getPozajmice(q = '') {
        return this._request('GET', `/pozajmica${q ? '?q=' + encodeURIComponent(q) : ''}`);
    },
    async addPozajmica(p) { return this._request('POST', '/pozajmica', p); },
    async vratiKnjigu(idPoz, idKnjiga) {
        return this._request('POST', `/pozajmica/${idPoz}/vrati/${idKnjiga}`);
    },
    async izmeniRok(idPoz, noviRok) {
        return this._request('PUT', `/pozajmica/${idPoz}/rok`, { noviRok });
    }
};

function toast(msg, type = 'success') {
    const t = document.createElement('div');
    t.className = `toast toast-${type}`;
    t.textContent = msg;
    document.body.appendChild(t);
    setTimeout(() => t.classList.add('show'), 10);
    setTimeout(() => { t.classList.remove('show'); setTimeout(() => t.remove(), 300); }, 3000);
}

async function requireAuth() {
    try {
        const status = await API.authStatus();
        if (!status.ulogovan) {
            window.location.replace('/login.html');
            return null;
        }
        return status;
    } catch {
        window.location.replace('/login.html');
        return null;
    }
}

function fmtDatum(d) {
    if (!d) return '—';
    return new Date(d).toLocaleDateString('sr-RS', {
        day: '2-digit', month: '2-digit', year: 'numeric'
    });
}