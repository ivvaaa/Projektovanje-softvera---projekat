function buildSidebar(activePage) {
    const nav = [
        { href: '/index.html', key: 'index', label: 'Pregled', icon: `<svg xmlns="http://www.w3.org/2000/svg" width="17" height="17" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><rect width="7" height="7" x="3" y="3" rx="1"/><rect width="7" height="7" x="14" y="3" rx="1"/><rect width="7" height="7" x="14" y="14" rx="1"/><rect width="7" height="7" x="3" y="14" rx="1"/></svg>` },
        { href: '/knjige.html', key: 'knjige', label: 'Knjige', icon: `<svg xmlns="http://www.w3.org/2000/svg" width="17" height="17" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H20v20H6.5a2.5 2.5 0 0 1 0-5H20"/></svg>` },
        { href: '/clanovi.html', key: 'clanovi', label: 'Članovi', icon: `<svg xmlns="http://www.w3.org/2000/svg" width="17" height="17" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M22 21v-2a4 4 0 0 0-3-3.87"/><path d="M16 3.13a4 4 0 0 1 0 7.75"/></svg>` },
        { href: '/pozajmice.html', key: 'pozajmice', label: 'Pozajmice', icon: `<svg xmlns="http://www.w3.org/2000/svg" width="17" height="17" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><polyline points="14,2 14,8 20,8"/><line x1="16" y1="13" x2="8" y2="13"/><line x1="16" y1="17" x2="8" y2="17"/><polyline points="10,9 9,9 8,9"/></svg>` },
    ];

    return `
  <div class="sidebar">
    <div class="sidebar-brand">
      <div class="sidebar-brand-icon">B</div>
      <div>
        <div class="sidebar-brand-text">Biblioteka</div>
        <div class="sidebar-brand-sub">Sistem</div>
      </div>
    </div>
    <nav class="sidebar-nav">
      <div class="nav-section-label">Navigacija</div>
      ${nav.map(n => `
        <a href="${n.href}" class="nav-link ${activePage === n.key ? 'active' : ''}">
          <span class="nav-link-icon">${n.icon}</span>
          <span>${n.label}</span>
        </a>`).join('')}
    </nav>
    <div class="sidebar-footer">
      <div class="sidebar-user" id="sidebarUser">—</div>
      <button class="btn-logout" onclick="doLogout()">
        <svg xmlns="http://www.w3.org/2000/svg" width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M9 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h4"/><polyline points="16 17 21 12 16 7"/><line x1="21" y1="12" x2="9" y2="12"/></svg>
        Odjavi se
      </button>
    </div>
  </div>`;
}

function initPage(activePage, status) {
    document.querySelector('.app-shell').insertAdjacentHTML('afterbegin', buildSidebar(activePage));
    if (status?.ime) {
        const el = document.getElementById('sidebarUser');
        if (el) el.textContent = status.ime;
    }
}

async function doLogout() {
    try { await API.logout(); } catch { }
    window.location.replace('/login.html');
}