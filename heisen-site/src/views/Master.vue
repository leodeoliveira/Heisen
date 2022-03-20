/* eslint-disable vue/multi-word-component-names */
<template>
  <!-- tap on top starts-->
    <div class="tap-top"><i data-feather="chevrons-up"></i></div>
    <!-- tap on tap ends-->
    <!-- page-wrapper Start-->
    <div class="page-wrapper compact-wrapper" id="pageWrapper">
        <header-section></header-section>
        <menu-section></menu-section>    
        <router-view></router-view>
        
        <footer-section></footer-section>
    </div>

</template>

<script>
import HeaderSection from '../components/frontend/Header.vue'
import FooterSection from '../components/frontend/Footer.vue'
import MenuSection from '../components/frontend/Menu.vue'

export default {
    name: 'HtmlMaster',
    components: {
        HeaderSection,
        FooterSection,
        MenuSection,
    }

};
</script>