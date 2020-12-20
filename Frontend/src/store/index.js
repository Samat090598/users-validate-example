import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex);

let store = new Vuex.Store({
    actions: {
        POST_USER_INFO({commit}, {user}) {
            return axios.post('http://localhost:5000/users/addUser', user)
                .then((response) => {
                    return response;
                })
        }
    }
});

export default store;