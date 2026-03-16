// Centralni API helper — sve fetch() pozive ide kroz ove funkcije
// Zamenjuje Komunikacija.cs iz desktop aplikacije

const API = {
  base: '/api',

  async _request(method, url, body = null) {
    const opts = {
      method,
      headers: { 'Content-Type': 'application/json' },
      credentials: 'include'
    };
    if (body) opts.body = JSON.stringify(body);
    const res = await fetch(this.base + url, opts);
    const data = await res.json();
    if (!data.signal && data.poruka) throw new Error(data.poruka);
    return data.podaci ?? data;
  },

  // AUTH
  async login(username, password) {
    return this._request('POST', '/auth/login', { username, password });
  },
  async logout() {
    return this._request('POST', '/auth/logout');
  },
  async authStatus() {
    return this._request('GET', '/auth/status');
  },

  // KNJIGE
  async getKnjige(q = '') {
    return this._request('GET', `/knjiga${q ? '?q=' + encodeURIComponent(q) : ''}`);
  },
  async addKnjiga(knjiga) {
    return this._request('POST', '/knjiga', knjiga);
  },
  async updateKnjiga(id, knjiga) {
    return this._request('PUT', `/knjiga/${id}`, knjiga);
  },
  async deleteKnjiga(id) {
    return this._request('DELETE', `/knjiga/${id}`);
  },

  // CLANOVI
  async getClanovi(q = '') {
    return this._request('GET', `/clan${q ? '?q=' + encodeURIComponent(q) : ''}`);
  },
  async getClanstva() {
    return this._request('GET', '/clan/clanstva');
  },
  async addClan(clan) {
    return this._request('POST', '/clan', clan);
  },
  async updateClan(id, clan) {
    return this._request('PUT', `/clan/${id}`, clan);
  },
  async deleteClan(id) {
    return this._request('DELETE', `/clan/${id}`);
  },

  // POZAJMICE
  async getPozajmice(q = '') {
    return this._request('GET', `/pozajmica${q ? '?q=' + encodeURIComponent(q) : ''}`);
  },
  async addPozajmica(poz) {
    return this._request('POST', '/pozajmica', poz);
  },
  async vratiKnjigu(idPoz, idKnjiga) {
    return this._request('POST', `/pozajmica/${idPoz}/vrati/${idKnjiga}`);
  },
  async izmeniRok(idPoz, noviRok) {
    return this._request('PUT', `/pozajmica/${idPoz}/rok`, { noviRok });
  }
};

// Globalni toast notifikacija
function toast(msg, type = 'success') {
  const t = document.createElement('div');
  t.className = `toast toast-${type}`;
  t.textContent = msg;
  document.body.appendChild(t);
  setTimeout(() => t.classList.add('show'), 10);
  setTimeout(() => { t.classList.remove('show'); setTimeout(() => t.remove(), 300); }, 3000);
}

// Redirect na login ako nije prijavljen
async function requireAuth() {
  try {
    const status = await API.authStatus();
    if (!status.ulogovan) window.location.href = '/login.html';
    return status;
  } catch {
    window.location.href = '/login.html';
  }
}

// Format datum za prikaz
function fmtDatum(d) {
  if (!d) return '—';
  return new Date(d).toLocaleDateString('sr-RS', { day: '2-digit', month: '2-digit', year: 'numeric' });
}
