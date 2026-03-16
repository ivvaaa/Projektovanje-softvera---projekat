// Shared sidebar — poziva se na svakoj stranici
function buildSidebar(activePage) {
  const nav = [
    { href: 'index.html',     icon: '▦',  label: 'Pregled',    key: 'index' },
    { href: 'knjige.html',    icon: '📚', label: 'Knjige',     key: 'knjige' },
    { href: 'clanovi.html',   icon: '👤', label: 'Članovi',    key: 'clanovi' },
    { href: 'pozajmice.html', icon: '📋', label: 'Pozajmice',  key: 'pozajmice' },
  ];

  return `
  <div class="sidebar">
    <div class="sidebar-brand">
      <div class="sidebar-brand-icon">📚</div>
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
          ${n.label}
        </a>`).join('')}
    </nav>
    <div class="sidebar-footer">
      <div class="sidebar-user" id="sidebarUser">—</div>
      <button class="btn-logout" onclick="doLogout()">Odjavi se</button>
    </div>
  </div>`;
}

async function initPage(activePage) {
  document.querySelector('.app-shell').insertAdjacentHTML('afterbegin', buildSidebar(activePage));
  const status = await requireAuth();
  if (status && status.ime) {
    document.getElementById('sidebarUser').textContent = status.ime;
  }
}

async function doLogout() {
  try { await API.logout(); } catch {}
  window.location.href = '/login.html';
}
