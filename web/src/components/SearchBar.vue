<template>
  <div class="search-bar">
    <input
      v-model="searchQuery"
      class="search-input"
      type="text"
      placeholder="Pesquisar..."
    />
    <button @click="search" class="search-button">Pesquisar</button>
  </div>
</template>

<script>
// export default {
//   data() {
//     return {
//       searchQuery: "",
//     };
//   },
//   methods: {
//     search() {
//       // Enviar a consulta para a API ou executar a lógica desejada aqui
//       this.$emit("search", this.searchQuery);
//     },
//   },
// };
</script>

<style scoped>
.search-bar {
  display: flex;
  align-items: center;
}

.search-input {
  flex: 1;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
  margin-right: 8px;
}

.search-button {
  padding: 8px;
  background-color: #4caf50;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
</style>
