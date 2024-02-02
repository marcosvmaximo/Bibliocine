<template>
  <div class="auth-form">
    <h2>Registrar</h2>
    <form @submit.prevent="submitForm">
      <div class="form-group">
        <label for="name">Nome:</label>
        <input type="text" v-model="name" required />
      </div>
      <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" v-model="email" required />
      </div>
      <div class="form-group">
        <label for="password">Senha:</label>
        <input type="password" v-model="password" required />
      </div>
      <div class="form-group">
        <label for="confirmPassword">Confirmar Senha:</label>
        <input type="password" v-model="confirmPassword" required />
      </div>
      <button type="submit">Registrar</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: "",
      email: "",
      password: "",
      confirmPassword: "",
    };
  },
  methods: {
    submitForm() {
      // Lógica para processar o formulário de registro
      console.log("Formulário de Registro Enviado");
    },
  },
};
</script>

<style scoped>
/* Adicione estilos CSS conforme necessário */
</style>
