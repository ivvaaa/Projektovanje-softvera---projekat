/* sidebar.js — novi dizajn, folder tabs */

const ICONS = {
    logout: `<svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M9 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h4"/><polyline points="16 17 21 12 16 7"/><line x1="21" y1="12" x2="9" y2="12"/></svg>`
};

const NAV_ITEMS = [
    { href: '/index.html', key: 'index', label: 'Pregled', num: '01', indent: '0px' },
    { href: '/knjige.html', key: 'knjige', label: 'Knjige', num: '02', indent: '10px' },
    { href: '/clanovi.html', key: 'clanovi', label: 'Clanovi', num: '03', indent: '20px' },
    { href: '/pozajmice.html', key: 'pozajmice', label: 'Pozajmice', num: '04', indent: '30px' },
];

function buildSidebar(activePage) {
    const tabs = NAV_ITEMS.map(n => `
        <a href="${n.href}"
           class="folder-tab${activePage === n.key ? ' active' : ''}"
           style="margin-left:${n.indent}">
            <span class="tab-num">${n.num}</span>
            <span>${n.label}</span>
        </a>`).join('');

    return `
    <aside class="sidebar">
        <div class="sidebar-logo">
            <div class="logo-mark">B</div>
            <span class="logo-text">Biblioteka</span>
        </div>
        <nav class="sidebar-nav">
            <p class="nav-section-label">Navigacija</p>
            <div class="folder-tabs">${tabs}</div>
        </nav>
        <div class="sidebar-footer">
            <div class="user-avatar" id="sidebarInitials">—</div>
            <div class="user-info">
                <div class="user-name"  id="sidebarUser">—</div>
                <div class="user-role">Bibliotekar</div>
            </div>
            <button class="logout-btn" onclick="doLogout()" title="Odjavi se">
                ${ICONS.logout}
            </button>
        </div>
    </aside>`;
}

function initPage(activePage, status) {
    document.querySelector('.app-shell').insertAdjacentHTML('afterbegin', buildSidebar(activePage));

    if (status?.ime) {
        const el = document.getElementById('sidebarUser');
        if (el) el.textContent = status.ime;

        const initEl = document.getElementById('sidebarInitials');
        if (initEl) {
            const parts = status.ime.trim().split(' ');
            initEl.textContent = parts.length >= 2
                ? parts[0][0] + parts[1][0]
                : parts[0].substring(0, 2);
        }
    }
}

async function doLogout() {
    try { await API.logout(); } catch { }
    window.location.replace('/login.html');
}