<template>
<div class="page-body">
    <div class="col-sm-12">
    <div class="card">
        <div class="card-header">
        <h5>Cadastro de usuários</h5>
        <span>Use a class <code>table-hover</code> to enable a hover state on table rows within a <code>tbody</code>.</span>
        </div>
        <div class="table-responsive">
        <table class="table table-hover">
            <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Nome</th>
                <th scope="col">Nome de usuário</th>
                <th scope="col">Tipo de acesso</th>
                <th scope="col">Ativo</th>
            </tr>
            </thead>
            <tbody>
                <tr v-for="user in allUsers" :key="user.UserId">
                    <th scope="row">{{user.UserId}}</th>
                    <td>{{user.UserId}}</td>
                    <td>{{user.Name}}</td>
                    <td>Barbeiro</td>
                    <td>Sim</td>
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
  name: "UserList",
  data() {
      return {
        allUsers: []
      }
  },
  mounted() {
      api.get('user').then( response => {
          this.allUsers = response.data;
      });
  },    
};
</script>
