<template>
  <div class="container">
    <div v-if="loading" class="loading-message">Carregando...</div>
    <div v-else-if="favoritos.length > 0" class="list-container">
      <h1 class="titulo">Suas Obras Favoritas</h1>
      <div class="obras-container">
        <div v-for="obra in favoritos" :key="obra.id" class="card">
          <img :src="obra.imagemUrl" alt="Imagem da Obra" class="imagem-obra" />
          <div class="info-obra">
            <h2 class="titulo-obra">
              Título: {{ obra.titulo }} 
              ({{ obra.tipo === 1 ? 'Livro' : 'Filme' }})
            </h2>
            <p class="autor-obra">Autor: {{ obra.autorOuDiretor }}</p>
            <p class="data-lancamento-obra">Data de Lançamento: {{ obra.dataLancamento }}</p>
            <p class="descricao-obra">Descrição: {{ truncatedDescription(obra.descricao) }}</p>
            <div class="generos-obra">
              Gêneros: 
              <span v-for="genero in obra.generos" :key="genero">{{ genero }}</span>
            </div>
          </div>
          <button @click="removerFavorito(obra.id)" class="btn-remover">X</button>
        </div>
      </div>
    </div>
    <div v-else class="no-results-message">Nenhum favorito encontrado.</div>
  </div>
</template>

<script setup>
import BibliocineApiService from "@/services/BibliocineApiService.ts";
import { ref, onMounted } from 'vue';

let favoritos = ref([]);
let loading = ref(true);

const carregarFavoritos = async () => {
  try {
    const user = sessionStorage.getItem("user");
    const token = sessionStorage.getItem("token");
    const userId = JSON.parse(user).id;

    const response = await BibliocineApiService.getFavorites(userId, token);

    if (response.data.success) {
      favoritos.value = response.data.result
    } else {
      alert("Erro ao carregar favoritos");
    }
  } catch (error) {
    console.error('Erro ao carregar favoritos:', error);
  } finally {
    loading.value = false;
  }
};

const removerFavorito = async (obraId) => {

  const confirmacao = window.confirm('Tem certeza de que deseja remover este favorito?');

  if (confirmacao) {
    try {
      const user = sessionStorage.getItem("user");
      const token = sessionStorage.getItem("token");
      const userId = JSON.parse(user).id;

      const response = await BibliocineApiService.deleteFavorite(userId, obraId, token);

      favoritos.value = favoritos.value.filter(obra => obra.id !== obraId);
    } catch (error) {
      console.error('Erro ao remover favorito:', error);
    }
  } else {
    console.log('Remoção de favorito cancelada pelo usuário.');
  }
};

const truncatedDescription = (description) => {
  const maxLength = 300;
  if (description?.length > maxLength) {
    return description.slice(0, maxLength) + '...';
  }
  return description;
};

onMounted(carregarFavoritos);

</script>
<style scoped>
.loading-message {
  text-align: center;
  font-size: 18px;
  margin-top: 20px;
}

.no-results-message {
  text-align: center;
  font-size: 18px;
  margin-top: 20px;
  color: red;
}
.list-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  align-content: center;
  margin-top: 5rem;
}

.container {
  margin: 0 auto;
  /* display: flex;
  flex-direction: column; */
}

h1, h2 {
  display: inline;
  font-size: 28px;
  margin-bottom: 5px;
  color: var(--color-heading);
}

.obras-container {
  display: flex;
  flex-wrap: wrap;
}

.card {
  border: 1px solid #ccc;
  border-radius: 8px;
  margin: 10px;
  padding: 15px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-grow: 1; 
}

.imagem-obra {
  max-width: 150px;
  max-height: 200px;
  margin-right: 15px;
  border-radius: 5px;
}

.info-obra {
  flex: 1;
  margin-right: 4rem;
}

.titulo-obra {
  font-size: 20px;
  margin-bottom: 5px;
}

.autor-obra,
.data-lancamento-obra,
.descricao-obra {
  font-size: 14px;
  margin-bottom: 5px;
}

.generos-obra span {
  margin-right: 5px;
}

.btn-remover {
  background-color: red;
  color: #fff;
  border: none;
  padding: 8px 15px;
  cursor: pointer;
  border-radius: 5px;
  font-size: 16px;
}


.search-container {
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 20px 0;
}

.search-input {
  padding: 10px;
  width: 300px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 16px;
  margin-right: 10px;
}

.search-button {
  padding: 10px;
  background-color: #4caf50;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
}

.search-button:hover {
  background-color: #45a049;
}

.obras-container{
  width: 900px;
}


</style>
