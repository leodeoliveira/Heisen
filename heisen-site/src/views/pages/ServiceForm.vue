<template>
  <div class="page-body">
        <div class="col-sm-12">
          <div class="card">
            <div class="card-header">
              <h5>Cadastrar serviço</h5>
            </div>
            <form class="form theme-form" v-on:submit.prevent="submitForm">
              <div class="card-body">
                <div class="row">
                  <div class="col">
                    <div class="mb-3">
                      <label class="form-label" for="Nome">Nome</label>
                      <input class="form-control" id="exampleFormControlInput1" type="text" v-model="form.Name" />
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col">
                    <div class="mb-3">
                      <label class="form-label" for="exampleInputPassword2">Valor</label>
                      <input class="form-control" id="exampleInputPassword2" type="text" v-model="form.Price"/>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col">
                    <div class="mb-3">
                      <label class="form-label" for="exampleInputPassword2">Tabela de preço</label>
                      <select class="form-select input-air-primary digits" v-model="form.PriceTableId">
                        <option v-for="item in allPriceTables" v-bind:value="item._id" :key="item._id" >{{ item.Name }}</option>
                      </select>
                    </div>
                  </div>
                </div>
              </div>
              <div class="card-footer">
                <button class="btn btn-primary" type="submit">Cadastrar</button>
                <a href="service" class="btn btn-light">Cancelar</a>
              </div>
            </form>
          </div>
        </div>
  </div>
</template>

<script>
import api from '../../services/api.js';

export default {
  name: "ServiceForm",
  data(){
        return{
            allPriceTables: [],
            form: {
                Name: '',
                Price: '',
                TablePriceId: '',
            }
            
        }
    },
    mounted() {
      api.get('priceTable').then( response => {
            this.allPriceTables = response.data;
        });
    },
    methods:{
        submitForm(){
            let formData = JSON.parse(JSON.stringify(this.form));
            console.log(formData);
            api.post('/service/add', formData)
                 .then(() => {
                   alert('Serviço cadastrado com sucesso.');
                    this.$router.push('/service');
                 })
                 .catch((error) => {
                     console.log(error +  "Fail");
                 }).finally(() => {
                 });
        }
    }
};
</script>
