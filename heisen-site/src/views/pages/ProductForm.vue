<template>
  <div class="page-body">
        <div class="col-sm-12">
          <div class="card">
            <div class="card-header">
              <h5>Cadastrar produto</h5>
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
                      <label class="form-label" for="exampleInputPassword2">Quantidade</label>
                      <input class="form-control" id="exampleInputPassword2" type="number" v-model="form.Quantity"/>
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col">
                    <div class="mb-3">
                      <label class="form-label" for="exampleInputPassword2">Comissão de vendas</label>
                      <input class="form-control" id="exampleInputPassword2" type="number" v-model="form.Percentage"/>
                    </div>
                  </div>
                </div>
              </div>
              <div class="card-footer">
                <button class="btn btn-primary" type="submit">Cadastrar</button>
                <a href="product" class="btn btn-light">Cancelar</a>
              </div>
            </form>
          </div>
        </div>
  </div>
</template>

<script>
import api from '../../services/api.js';

export default {
  name: "ProductPage",
  data(){
        return{
            form: {
                Name: '',
                Price: ''
            }
        }
    },
    methods:{
        submitForm(){
            let formData = JSON.parse(JSON.stringify(this.form));
            console.log(formData);
            api.post('/product/add', formData)
                 .then(() => {
                   alert('Produto cadastrado com sucesso.');
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
