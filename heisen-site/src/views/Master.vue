/* eslint-disable vue/multi-word-component-names */
<template>
  <!-- tap on top starts-->
    <div class="tap-top"><i data-feather="chevrons-up"></i></div>
    <!-- tap on tap ends-->
    <!-- page-wrapper Start-->
    <div class="page-wrapper compact-wrapper" id="pageWrapper">
        <header-section></header-section>
        <menu-section></menu-section>        

        
        <div class="page-body">
          <div class="container-fluid">
            <div class="page-title">
              <div class="row">
                <div class="col-6">
                  <h3>Layout Light</h3>
                </div>
                <div class="col-6">
                  <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="index.html">                                       <i data-feather="home"></i></a></li>
                    <li class="breadcrumb-item">Color version</li>
                    <li class="breadcrumb-item active">Layout light</li>
                  </ol>
                </div>
              </div>
            </div>
          </div>
          <!-- Container-fluid starts-->
          <div class="container-fluid">
            <div class="row starter-main">
              <div class="col-sm-12">
                <div class="card">
                  
                </div>
              </div>
            </div>
          </div>
          <!-- Container-fluid Ends-->
        </div>


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
        MenuSection
    }

};
</script>