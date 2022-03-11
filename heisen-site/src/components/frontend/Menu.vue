<template>
    <div class="page-body-wrapper horizontal-menu">
        <div class="sidebar-wrapper">
            <div>
            <div class="logo-wrapper"><a href="index.html"><img class="img-fluid for-light" src="/frontend/assets/images/logo/logo.png" alt=""><img class="img-fluid for-dark" src="/frontend/assets/images/logo/logo_dark.png" alt=""></a>
                <div class="back-btn"><i class="fa fa-angle-left"></i></div>
                <div class="toggle-sidebar"><i class="status_toggle middle sidebar-toggle" data-feather="grid"> </i></div>
            </div>
            <div class="logo-icon-wrapper"><a href="index.html"><img class="img-fluid" src="/frontend/assets/images/logo/logo-icon.png" alt=""></a></div>
            <nav class="sidebar-main">
                <div class="left-arrow" id="left-arrow"><i data-feather="arrow-left"></i></div>
                <div id="sidebar-menu">
                <ul class="sidebar-links" id="simple-bar">
                    <li class="sidebar-list"><a class="sidebar-link sidebar-title" href="/frontend/theme/index.html" target="_blank"><i data-feather="home"></i><span>Dashboard</span></a></li>
                    <li class="sidebar-list"><a class="sidebar-link sidebar-title" href="http://support.pixelstrap.com/help-center" target="_blank"><i data-feather="headphones"></i><span>Raise Support</span></a></li>
                    <li class="sidebar-list"><a class="sidebar-link sidebar-title" href="/frontend/document/index.html" target="_blank"><i data-feather="file-text"></i><span>Documentation                                    </span></a></li>
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
    name: 'MenuSection'
}
</script>