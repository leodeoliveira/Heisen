<template>
  <div class="page-body">
        <div class="col-sm-12">
          <div class="card">
            <div class="card-header">
              <h5>Cadastrar comanda</h5>
            </div>
            <div class="card-body">

              <form class="form theme-form" v-on:submit.prevent="submitForm">
                  <div class="row g-3">
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label" for="clientNameLabel">Nome do cliente</label>
                        <input class="form-control" id="clientName" type="text" v-model="form.ClientName" required="Informe o nome do cliente"/>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-md-6">
                        <div class="mb-3">
                          <label class="form-label" for="exampleInputPassword2">Barbeiro</label>
                          <select class="form-select"  @change="BarberOnChange($event)"  v-model="form.UserId" required="Selecione o barbeiro que executou o serviço.">
                            <option v-for="item in allBarbers" :value="item.UserId" :key="item.UserId">
                              {{ item.Name }}
                            </option>
                          </select>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div class="row g-3">
                    <div class="col-sm-12">
                          <h5 class="mb-0">Serviços</h5>
                    </div>

                    <div class="col">
                      <div class="m-t-15 m-checkbox-inline">
                        <div class="form-check form-check-inline checkbox checkbox-dark mb-0" v-for="item in allServices" :key="item.IdReference">
                          <input class="form-check-input" :id="'inline-' + item.IdReference" type="checkbox" v-model="selectedServices" v-bind:value="{ IdReference: item.IdReference }">
                          <label class="form-check-label" :for="'inline-' + item.IdReference">{{item.Name}}</label>
                        </div>
                      </div>
                    </div>
                  </div>
                  
                  <div class="col-sm-12">
                          <h5 class="mb-0">Produtos</h5>
                  </div>

                  <div class="row g-3" v-for="(input, index) in selectedProducts" :key="index">
                    <div class="col-md-3">
                            <select class="form-select" v-model="selectedProducts[index].ProductId">
                              <option>Selecione um produto...</option>
                              <option v-for="product in allProducts" :value="product.ProductId" :key="product.ProductId">
                                {{ product.Name }}
                              </option>
                            </select>
                    </div>
                    <div class="col-md-1">
                      <input class="form-control" id="validationTooltip05" type="number" v-model="selectedProducts[index].Quantity" required>
                    </div>
                    <div class="col-sm-1">
                        <a @click.prevent="addProductField()" href=""><i class="icofont icofont-ui-add" /></a>
                        <a @click.prevent="removeProductField(index)" href=""><i class="icofont icofont-ui-remove" /></a>
                    </div>
                  </div>
                  <div class="col-sm-12">
                          <h5 class="mb-0">Bebidas</h5>
                  </div>
                  <div class="row g-3" v-for="(input, index) in selectedBeverages" :key="index">
                    <div class="col-md-3">
                            <select class="form-select" v-model="selectedBeverages[index].BeverageId">
                              <option selected="" disabled="" value="">Selecione uma bebida...</option>
                               <option v-for="bev in allBeverages" :value="bev.Name" :key="bev.BeverageId">
                                {{ bev.Name }}
                              </option>
                            </select>
                    </div>
                    <div class="col-md-1">
                      <input class="form-control" id="validationTooltip05" type="number"  v-model="selectedBeverages[index].Quantity" required>
                    </div>
                    <div class="col-sm-1">
                        <a @click.prevent="addBeverageField()" href=""><i class="icofont icofont-ui-add" /></a>
                        <a @click.prevent="removeBeverageField(index)" href=""><i class="icofont icofont-ui-remove" /></a>
                    </div>
                  </div>

                <div class="card-footer">
                  <button class="btn btn-primary" type="submit">Cadastrar</button>
                  <a href="order" class="btn btn-light">Cancelar</a>
                </div>
              </form>
            </div>
            
          </div>
        </div>
  </div>
</template>

<script>
import api from '../../services/api.js';

export default {
  name: "OrderPage",
  data(){
        return{
            arrayProducts: [],
            selectedServices: [],
            allBarbers: [],
            allServices: [],
            allProducts: [],
            allBeverages: [],
            selectedProducts: [{ ProductId: '0', Quantity: '0'}],
            selectedBeverages: [{ BeverageId: '0', Quantity: '0'}],
            form: {
                Name: '',
                Price: ''
            }
        }
    },
    mounted() {
        api.get('user').then( response => {
            this.allBarbers = response.data;
        });

        api.get('product').then( response => {
          this.allProducts = response.data;
      });
    },
    methods:{
        addBeverageField:function() {
          this.allBeverages.push({ BeverageId: '0', Quantity: '0'});
        },
        removeBeverageField:function(index) {
          this.allBeverages.splice(index, 1);
        },

        addProductField:function() {
          this.selectedProducts.push({ ProductId: '0', Quantity: '0'});
        },
        removeProductField:function(index) {
          this.selectedProducts.splice(index, 1);
        },

        BarberOnChange:function(event) {
          var barberId = event.target.value;
          var fullURL = "/service/GetServicesByBarberId/" + barberId;
          api.get(fullURL).then( response => {
            this.allServices = response.data;
          });
        },

        submitForm(){
            let formData = this.form;
            formData.Services = this.selectedServices;
            formData.Products = this.selectedProducts;
            formData.Beverages = this.selectedBeverages;
            let formDataParsed = JSON.parse(JSON.stringify(formData));
            console.log(formDataParsed);
            api.post('/order/add', formDataParsed)
                 .then(() => {
                   alert('Comanda cadastrada com sucesso.');
                    this.$router.push('/product');
                 })
                 .catch((error) => {
                     console.log(error +  "Fail");
                 }).finally(() => {
                     //Perform action in always
                 });
        }
    }
};
</script>
