<template>
  <div class="page-body">
        <div class="col-sm-12">
          <div class="card">
            <div class="card-header">
              <h5>Cadastrar comanda</h5>
            </div>
            <form class="form theme-form" v-on:submit.prevent="submitForm">
              <div class="card-body">
                <div class="row">
                  <div class="col">
                    <div class="mb-3">
                      <label class="form-label" for="exampleInputPassword2">Nome do cliente</label>
                      <input class="form-control" id="exampleInputPassword2" type="text" v-model="form.ClientName" required/>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col">
                      <div class="mb-3">
                        <label class="form-label" for="exampleInputPassword2">Barbeiro</label>
                        <select class="form-select"  @change="BarberOnChange($event)"  v-model="form.UserId" required>
                          <option v-for="item in allBarbers" :value="item.UserId" :key="item.UserId">
                            {{ item.Name }}
                          </option>
                        </select>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="row">
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
                {{selectedServices}}
                <div class="row">
                  <div class="col-sm-12">
                        <h5 class="mb-0">Produtos</h5>
                  </div>
                  <div class="col">
                    <div class="m-t-15 m-checkbox-inline">
                      <div class="form-check form-check-inline checkbox checkbox-dark mb-0">
                        <input class="form-check-input" id="inline-1" type="checkbox" data-bs-original-title="" title="">
                        <label class="form-check-label" for="inline-1">Blend Barba</label>
                      </div>
                      <div class="form-check form-check-inline checkbox checkbox-dark mb-0">
                        <input class="form-check-input" id="inline-2" type="checkbox" data-bs-original-title="" title="">
                        <label class="form-check-label" for="inline-2">Pomada Matte</label>
                      </div>
                      <div class="form-check form-check-inline checkbox checkbox-dark mb-0">
                        <input class="form-check-input" id="inline-3" type="checkbox" data-bs-original-title="" title="">
                        <label class="form-check-label" for="inline-3">Pomada efeito molhado</label>
                      </div>
                      <div class="form-check form-check-inline checkbox checkbox-dark mb-0">
                        <input class="form-check-input" id="inline-3" type="checkbox" data-bs-original-title="" title="">
                        <label class="form-check-label" for="inline-3">Pente barba</label>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="row">
                  <div class="col-sm-12">
                        <h5 class="mb-0">Bebidas</h5>
                  </div>
                  <div class="col">
                    <div class="m-t-15 m-checkbox-inline">
                      <div class="form-check form-check-inline checkbox checkbox-dark mb-0">
                        <input class="form-check-input" id="inline-1" type="checkbox" data-bs-original-title="" title="">
                        <label class="form-check-label" for="inline-1">Cerveja</label>
                      </div>
                      <div class="form-check form-check-inline checkbox checkbox-dark mb-0">
                        <input class="form-check-input" id="inline-2" type="checkbox" data-bs-original-title="" title="">
                        <label class="form-check-label" for="inline-2">Chopp</label>
                      </div>
                      <div class="form-check form-check-inline checkbox checkbox-dark mb-0">
                        <input class="form-check-input" id="inline-3" type="checkbox" data-bs-original-title="" title="">
                        <label class="form-check-label" for="inline-3">Café</label>
                      </div>
                      <div class="form-check form-check-inline checkbox checkbox-dark mb-0">
                        <input class="form-check-input" id="inline-3" type="checkbox" data-bs-original-title="" title="">
                        <label class="form-check-label" for="inline-3">Regrigerante</label>
                      </div>
                      <div class="form-check form-check-inline checkbox checkbox-dark mb-0">
                        <input class="form-check-input" id="inline-3" type="checkbox" data-bs-original-title="" title="">
                        <label class="form-check-label" for="inline-3">Água</label>
                      </div>
                    </div>
                  </div>
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
</template>

<script>
import api from '../../services/api.js';

export default {
  name: "OrderPage",
  data(){
        return{
            selectedServices: [],
            allBarbers: [],
            allServices: [],
            allProducts: [],
            allBeverages: [],
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

         api.get('service').then( response => {
            this.allServices = response.data;
        });
    },
    methods:{
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
