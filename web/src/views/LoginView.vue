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

    <div v-if="errorMessages.length > 0" class="error-alert">
      <p v-for="(error, index) in errorMessages" :key="index">{{ error.value }}</p>
    </div>
  </div>
</template>

<script>
import BibliocineApiService from "../services/BibliocineApiService.ts";

export default {
  data() {
    return {
      email: '',
      password: '',
      errorMessages: [],
    };
  },
  methods: {
    async submitForm() {
      this.errorMessages = [];

      var data = {
        email: this.email,
        senha: this.password
      };

      try {
        const response = await BibliocineApiService.login(data);

        window.location.reload();
        this.$router.push('/catalogo');

        sessionStorage.setItem('token', response.data.result.token);
        sessionStorage.setItem('user', JSON.stringify(response.data.result.user));
      } catch (error) {
        console.error(error.response.data.result);

        if (error.response.data.result) {
          this.errorMessages = error.response.data.result;
        }
      }
    },
  },
};
</script>
<style scoped>
.auth-form {
  max-width: 400px;
  margin: 5% auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 8px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

h2 {
  text-align: center;
  color: #333;
}

form {
  display: flex;
  flex-direction: column;
}

.form-group {
  margin-bottom: 15px;
}

label {
  font-weight: bold;
  margin-bottom: 5px;
}

input {
  padding: 10px;
  width: 100%;
  box-sizing: border-box;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 16px;
}

button {
  padding: 10px;
  background-color: var(--color-link);
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
}

button:hover {
  background-color: #217dbb;
}

.error-alert {
  background-color: #ffcccc;
  padding: 10px;
  border: 1px solid #ff0000;
  border-radius: 4px;
  margin-top: 15px;
}

.error-alert p {
  color: #ff0000;
  margin: 0;
}
</style>