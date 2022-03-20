<template>
    <footer class="footer footer-fix">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 footer-copyright text-center">
            <p class="mb-0">Copyright 2022 © Desenvolvido por sloft.</p>
            </div>
        </div>
        </div>
    </footer>
</template>

<script>
    export default {
        name: 'FooterSection',
        mounted() {
        let localScripts = document.createElement('script');
        localScripts.setAttribute('src', 'frontend/assets/js/icons/feather-icon/feather-icon.js');
        document.head.appendChild(localScripts)
        },
    }
</script>