<template>
  <div class="auth-form">
    <h2>Login</h2>
    <form @submit.prevent="submitForm">
      <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" v-model="email" required />
      </div>
      <div class="form-group">
        <label for="password">Senha:</label>
        <input type="password" v-model="password" required />
      </div>
      <button type="submit">Entrar</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    submitForm() {
      // Lógica para processar o formulário de login
      console.log("Formulário de Login Enviado");
    },
  },
};
</script>

<style scoped>
/* Adicione estilos CSS conforme necessário */
</style>
