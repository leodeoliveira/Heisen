<template>
<div class="page-body">
    <div class="col-sm-12">
    <div class="card">
        <div class="card-header">
        <h5>Clientes</h5>
        <span>Use a class <code>table-hover</code> to enable a hover state on table rows within a <code>tbody</code>.</span>
        </div>
        <div class="table-responsive">
        <table class="table table-hover">
            <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Nome</th>
                <th scope="col">Preço</th>
                <th scope="col">Ativo</th>
            </tr>
            </thead>
            <tbody>
            <tr>
                <th scope="row">1</th>
                <td>Barba</td>
                <td>R$ 30,00</td>
                <td>Sim</td>
            </tr>
            <tr>
                <th scope="row">1</th>
                <td>Barba (Acabamento)</td>
                <td>R$ 30,00</td>
                <td>Sim</td>
            </tr>
            <tr>
                <th scope="row">1</th>
                <td>Cabelo</td>
                <td>R$ 30,00</td>
                <td>Sim</td>
            </tr>
            <tr>
                <th scope="row">1</th>
                <td>Sobrancelha</td>
                <td>R$ 10,00</td>
                <td>Sim</td>
            </tr>
            <tr>
                <th scope="row">1</th>
                <td>Massagem Capilar</td>
                <td>R$ 20,00</td>
                <td>Sim</td>
            </tr>
            <tr>
                <th scope="row">1</th>
                <td>Cabelo (pezinho)</td>
                <td>R$ 20,00</td>
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
export default {
  name: "CustomerList",
};
</script>
