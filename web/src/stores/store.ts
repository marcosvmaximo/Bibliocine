// // store.js
// import { createStore } from 'vuex';

// export default createStore({
//   state: {
//     token: null,
//     user: null,
//   },
//   mutations: {
//     setToken(state, token) {
//       state.token = token;
//     },
//     setUser(state, user) {
//       state.user = user;
//     },
//     logout(state) {
//       state.token = null;
//       state.user = null;
//     },
//   },
//   actions: {
//     login({ commit }, { token, user }) {
//       commit('setToken', token);
//       commit('setUser', user);
//     },
//     logout({ commit }) {
//       commit('logout');
//     },
//   },
//   getters: {
//     isAuthenticated: (state) => !!state.token,
//     getUser: (state) => state.user,
//   },
// });
