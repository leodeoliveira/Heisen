<template>
  <div class="page-body">
        <div class="col-sm-12">
          <div class="card">
            <div class="card-header">
              <h5>Cadastrar barbeiro</h5>
            </div>
            <form class="form theme-form" v-on:submit.prevent="submitForm">
              <div class="card-body">
                <div class="row">
                  <div class="col">
                    <div class="mb-3">
                      <label class="form-label" for="Nome">Nome</label>
                      <input class="form-control" id="exampleFormControlInput1" type="text" v-model="form.name" />
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col">
                    <div class="mb-3">
                      <label class="form-label" for="exampleInputPassword2">Tipo de acesso</label>
                      <input class="form-control" id="exampleInputPassword2" type="text" v-model="form.privilegies"/>
                    </div>
                  </div>
                </div>
              </div>
              <div class="card-footer">
                <button class="btn btn-primary" type="submit">Cadastrar</button>
                <input class="btn btn-light" type="reset" value="Cancelar" />
              </div>
            </form>
          </div>
        </div>
  </div>
</template>

<script>
import api from '../../services/api.js';

export default {
  name: "UserPage",
  data(){
        return{
            form: {
                name: '',
                privilegies: ''
            }
        }
    },
    methods:{
        submitForm(){
            let formData = JSON.parse(JSON.stringify(this.form));
            console.log(formData);
            api.post('/user/add', formData)
                 .then((res) => {
                     console.log(res + "Sucess");
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
