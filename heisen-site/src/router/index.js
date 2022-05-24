import { createWebHistory, createRouter } from "vue-router";
import Home from "@/views/pages/Login.vue";
import ProductForm from "@/views/pages/ProductForm.vue";
import ServiceForm from "@/views/pages/ServiceForm.vue";
import OrderForm from "@/views/pages/OrderForm.vue";
import OrderList from "@/views/pages/Order.vue";
import ProductList from "@/views/pages/Product.vue";
import ServiceList from "@/views/pages/Service.vue";
import UserList from "@/views/pages/User.vue";
import UserForm from "@/views/pages/UserForm.vue";
import CustomerList from "@/views/pages/Customer.vue";

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
    path: "/product",
    name: "ProductList",
    component: ProductList,
  },
  {
    path: "/service",
    name: "ServiceList",
    component: ServiceList,
  },
  {
    path: "/order",
    name: "OrderList",
    component: OrderList,
  },
  {
    path: "/orderForm",
    name: "Order",
    component: OrderForm,
  },
  {
    path: "/user",
    name: "User",
    component: UserList,
  },
  {
    path: "/userForm",
    name: "User",
    component: UserForm,
  },
  {
    path: "/customer",
    name: "Customer",
    component: CustomerList,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;