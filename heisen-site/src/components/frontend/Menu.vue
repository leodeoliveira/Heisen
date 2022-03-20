<template>
    <div class="page-body-wrapper horizontal-menu">
        <div class="sidebar-wrapper">
            <div>
            <div class="logo-wrapper"><a href="index.html"><img class="img-fluid for-light" src="/frontend/assets/images/logo/logo2.png" alt=""></a>
                <div class="toggle-sidebar"><i class="icon-settings" data-feather="grid"> </i></div>
            </div>
            <div class="logo-icon-wrapper"><a href="index.html"><img class="img-fluid" src="/frontend/assets/images/logo/logo-icon.png" alt=""></a></div>
            <nav class="sidebar-main">
                <div class="left-arrow" id="left-arrow"><i data-feather="arrow-left"></i></div>
                <div id="sidebar-menu">
                <ul class="sidebar-links" id="simple-bar">
                    <li class="back-btn"><a href="index.html"><img class="img-fluid" src="frontend/assets/images/logo/logo-icon.png" alt=""></a>
                        <div class="mobile-back text-end"><span>Back</span><i class="fa fa-angle-right ps-2" aria-hidden="true"></i></div>
                    </li>
                    <li class="sidebar-main-title">
                        <div>
                        <h6 class="lan-1">General</h6>
                        <p class="lan-2">Dashboards,widgets & layout.</p>
                        </div>
                    </li>
                    <li class="sidebar-list"><a class="sidebar-link sidebar-title" href="/frontend/theme/index.html" target="_blank"><i data-feather="dollar-sign"></i><span>Comandas</span></a></li>
                    <li class="sidebar-list"><a class="sidebar-link sidebar-title" href="http://support.pixelstrap.com/help-center" target="_blank"><i data-feather="user"></i><span>Barbeiros</span></a></li>
                    <li class="sidebar-list"><a class="sidebar-link sidebar-title" href="http://support.pixelstrap.com/help-center" target="_blank"><i data-feather="users"></i><span>Clientes</span></a></li>
                    <li class="sidebar-list"><router-link class="sidebar-link sidebar-title link-nav" to="/product"><i data-feather="file-text"></i><span>Produtos</span></router-link></li>
                    <li class="sidebar-list"><router-link class="sidebar-link sidebar-title link-nav" to="/service"><i data-feather="scissors"></i><span>Serviços</span></router-link></li>
                </ul>
                </div>
                <div class="right-arrow" id="right-arrow"><i data-feather="arrow-right"></i></div>
            </nav>
            </div>
        </div>
    </div>
</template>


<script>
export default {
    name: 'MenuSection',
    mounted() {
    let localScripts = document.createElement('script');
    localScripts.setAttribute('src', 'frontend/assets/js/scrollbar/simplebar.js');
    localScripts.setAttribute('src', 'frontend/assets/js/scrollbar/custom.js');
    document.head.appendChild(localScripts)
  },
}
</script>