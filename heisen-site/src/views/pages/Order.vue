<template>
<div class="page-body">
    <div class="col-sm-12">
    <div class="card">
       
         <div class="card-body">
            <div id="custom-button_wrapper" class="dataTables_wrapper container-fluid dt-bootstrap4">
                    <div class="dt-buttons btn-group">
                        <a href="orderForm" class="btn btn-primary">Adicionar comanda</a>
                </div>
            </div>
        </div>

        <div class="table-responsive">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="col">Data</th>
                    <th scope="col">Cliente</th>
                    <th scope="col">Valor</th>
                    <th scope="col">Pago</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in allOrders" :key="item._id">
                    <td>{{item.OrderDate}}</td>
                    <td>{{item.ClientName}}</td>
                    <td>R$ {{item.Total}}</td>
                    <td>{{item.Status === 3 ? "Sim" : "Não"}}</td>
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
        allOrders: []
      }
  },
  mounted() {
      api.get('order').then( response => {
          this.allOrders = response.data;
      });
  }   
};
</script>
