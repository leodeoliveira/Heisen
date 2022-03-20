import { createWebHistory, createRouter } from "vue-router";
import Home from "@/views/pages/Login.vue";
import ProductForm from "@/views/pages/ProductForm.vue";
import ServiceForm from "@/views/pages/ServiceForm.vue";
import OrderList from "@/views/pages/Order.vue";
import ProductList from "@/views/pages/Product.vue";
import ServiceList from "@/views/pages/Service.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/productForm",
    name: "Product",
    component: ProductForm,
  },
  {
    path: "/serviceForm",
    name: "Service",
    component: ServiceForm,
  },
  {
    path: "/productList",
    name: "Product",
    component: ProductList,
  },
  {
    path: "/serviceList",
    name: "Service",
    component: ServiceList,
  },
  {
    path: "/order",
    name: "Order",
    component: OrderList,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;