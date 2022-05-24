import Vue from "vue";
import Vuex from "vuex";
import Api from "@/services/api";

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        users: [],
        currentUser: {}
    },
    mutations: {
        LOGOUT_USER(state) {
            state.currentUser = {}
            window.localStorage.currentUser = JSON.stringify({});
        },
        SET_CURRENT_USER(state, user) {
            state.currentUser = user;
            window.localStorage.currentUser = JSON.stringify(user);
        },
    },
    actions: {
        async loadUsers({commit}) {
            let response = await Api().get('/user');
            let users = response.data.data;
            commit('SET_USERS', users.map(u => u.attributes));
            let user = JSON.parse(window.localStorage.currentUser);
            commit('SET_CURRENT_USER', user);
        },

        logoutUser({ commit }) {
            commit('LOGOUT_USER');
        },
        
        async loginUser({ commit }, loginInfo) {
            try 
            {
                let response = await Api().post('/sessions', loginInfo);
                let user = response.data.data.attributes;

                commit('SET_CURRENT_USER', user);
                return user;
            } catch {
            return { error: "Email/password combination was incorrect.  Please try again." }
            }
        }
    },
    modules: {},
    getters: {
        getTag: state => id => {
            return state.tags.find(t => t.id == id)
        }
    }
});