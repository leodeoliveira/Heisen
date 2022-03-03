<template>
    <header>
       <div class="header-logo-wrapper col-auto p-0">
            <div class="logo-wrapper"><a href="index.html"><img class="img-fluid" src="../assets//logo.jpg" alt=""></a></div>
            <div class="toggle-sidebar"><i class="status_toggle middle sidebar-toggle" data-feather="align-center"></i></div>
        </div>
    </header>
</template>

<script>
    export default {
        name: 'Header-site'
    }
</script>

<style scoped>
    
    header{
        background-color: var(--color-background-nav);
        width: 100%;
        height: 60px;
        display: flex;
        justify-content: center;
        align-items: center;
    }

    nav {
        display: flex;
        justify-content: space-between;
    }

    #logo {
        width: 130px; 

    }

    #menu-button {
        width: 30px;
    }

    #menu-overlay {
        position: 0;
        top: 0;
        left: 0;
        width: 40%;
        height: 100vh;
        background-color: #000000;
        opacity: 0.8;
    }

</style>