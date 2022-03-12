import { createRouter, createWebHistory } from "vue-router";
import Product from "..views/pages/Product.vue";

const routes: [
    {
        path: "/product",
        name: "Product",
        component: Product,
    },

];


const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
});

export default router;