import { createWebHistory, createRouter } from "vue-router";
import Home from "@/views/pages/Login.vue";
import ProductForm from "@/views/pages/Product.vue";
import ServiceForm from "@/views/pages/Service.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/product",
    name: "Product",
    component: ProductForm,
  },
  {
    path: "/service",
    name: "Service",
    component: ServiceForm,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;