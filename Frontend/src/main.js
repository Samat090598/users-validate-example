import Vue from 'vue'
import Vuelidate from "vuelidate";
import 'bootstrap/dist/css/bootstrap.min.css'
import App from './App.vue'
import store from './store/index'

Vue.use(Vuelidate);

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
  store
}).$mount('#app')
