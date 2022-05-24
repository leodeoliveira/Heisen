<template>
<div class="page-body">
    <div class="col-sm-12">
        <div class="card">

            <div class="card-body">
                <div id="custom-button_wrapper" class="dataTables_wrapper container-fluid dt-bootstrap4">
                        <div class="dt-buttons btn-group">
                            <a href="serviceForm" class="btn btn-primary">Adicionar serviço</a>
                    </div>
                </div>
            </div>

            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Nome</th>
                        <th scope="col">Preço</th>
                        <th scope="col">Tabela</th>
                    </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in allServices" :key="item._id">
                            <td>#</td>
                            <td>{{item.Name}}</td>
                            <td>R$ {{item.Price}}</td>
                            <td>{{item.PriceTable.Name}}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            
        </div>
    </div>
</div>

</template>

<script>
import api from '../../services/api.js';

export default {
  name: "OrderList",
data() {
      return {
        allServices: []
      }
  },
  mounted() {
      api.get('service').then( response => {
          this.allServices = response.data;
      });
  },    
};
</script>
