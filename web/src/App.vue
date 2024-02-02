<script setup lang="ts">
import { ref, watch, computed } from 'vue';
import { RouterLink, RouterView, useRouter } from 'vue-router';

const router = useRouter();

const isAuthenticated = ref(
  sessionStorage.getItem('token') !== null &&
    sessionStorage.getItem('user') !== null
);

const userString = computed(() => {
  return sessionStorage.getItem('user');
});

const userName = computed(() => {
  return isAuthenticated.value ? JSON.parse(userString.value).nome.split(' ')[0] : '';
});

const sair = () => {
  sessionStorage.removeItem('token');
  sessionStorage.removeItem('user');

  router.replace('/catalogo');
  window.location.reload();
};

watch(isAuthenticated, (newVal) => {
  console.log('Autenticação alterada:', newVal);
});

</script>

<template>
  <header>
    <img alt="Vue logo" class="logo" src="@/assets/logo-movie.svg" width="75" height="75" />

    <nav>
      <div>
        <ul>
          <li>
            <RouterLink to="/catalogo">Catalogo</RouterLink>
          </li>
          <li v-if="isAuthenticated">
            <RouterLink to="/favorito">Meus Favoritos</RouterLink>
          </li>
        </ul>
      </div>
      <div>
        <ul>
          <template v-if="!isAuthenticated">
            <li>
              <RouterLink to="/entrar">Entrar</RouterLink>
            </li>
            <li>
              <RouterLink  to="/registrar">Registrar</RouterLink>
            </li>
          </template>
          <template v-else>
            <li>
              <p class="login-text">Olá {{ userName }}</p>
            </li>
            <li>
              <button @click="sair"  class="login-text">Sair</button>
            </li>
          </template>
        </ul>
      </div>
    </nav>
  </header>
  <main>
    <RouterView />
  </main>
</template>

<style scoped>
.sair {
  padding: 0;
}

ul {
  list-style: none;
  padding: 0;
  margin: 0;
}

.login-text {
  margin: 0 2rem 0 0;
}

header {
  line-height: 1.5;
  max-height: 100vh;
  display: flex;
  place-items: center;
  background-color: rgb(83, 129, 214);
}

main {
  height: 100%;
}

.logo {
  display: block;
  margin: 1rem 0 1rem 2rem;
}

nav {
  width: 100%;
  font-size: 22px;
  text-align: center;
  padding: .5rem;
  display: flex;
  justify-content: space-between;
}

ul{
  display: flex;
  justify-content: space-between;
}

nav a {
  font-size: 18px;
  color: rgb(234, 236, 241);
  font-weight: normal;
}

nav p {
  font-size: 24px;
  font-weight: bold;
  color: rgb(234, 236, 241);
}

/* li{
  margin: 1rem;
} */

nav button{
  background: none;
  border: none;
  padding: 0;
  margin: 0;
  font-family: inherit;
  color: inherit;
  cursor: pointer;
  outline: inherit;
  font-size: 18px;
  color: rgb(234, 236, 241);
  font-weight: normal;
}

nav a.router-link-exact-active {
  color: rgb(255, 255, 255);
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}
</style>
