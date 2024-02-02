<template>
  <div class="container">
    <div class="search-container">
      <input v-model="searchTerm" class="search-input" placeholder="Buscar obras..." />
      <button @click="search" class="search-button">Pesquisar</button>
    </div>
    <div v-if="loading" class="loading-message">Carregando...</div>
    <div v-else-if="filteredObras.length > 0" class="list-container">
      <h1 class="titulo">Livros e Filmes relacionados</h1>
      <div class="obras-container">
        <div v-for="obra in filteredObras" :key="obra.id" class="card">
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
          <button @click="adicionarFavorito(obra.id, obra.tipoObra)" class="btn-adicionar">&#11088;</button>
        </div>
      </div>
    </div>
    <div v-else class="no-results-message">Nenhum resultado encontrado.</div>
  </div>
</template>

<script setup>
import BibliocineApiService from "@/services/BibliocineApiService.ts";
import { ref } from 'vue';

let searchTerm = '';
let filteredObras = ref([]);
let loading = ref(false);

const search = async () => {
  loading.value = true;

  try {
    const response = await BibliocineApiService.getAll(searchTerm);

    if (response.data.success) {
      filteredObras.value = response.data.result.filter(obra => obra.imagemUrl !== null);
    } else {
      window.location.alert("erro");
    }
  } catch (error) {
    console.error('Erro ao buscar obras:', error);
  } finally {
    loading.value = false;
  }
};

const adicionarFavorito = async (obraId, tipoObra) => {
  const user = sessionStorage.getItem("user");
  const token = sessionStorage.getItem("token");
  const userId = JSON.parse(user).id;

  const isAuthenticated = user !== null && token !== null;

  if (!isAuthenticated) {
    alert("Necessário estar logado para realizar essa ação");
    window.location.href = '/entrar';
    return;
  }

  try {
    const response = await BibliocineApiService.addFavorite(userId, obraId, tipoObra, token);

    console.log(response.data)
    if(response.data.success){
      alert("Adicionado ao seu favorito.");
    } else{
      if (Array.isArray(response.data.result) && response.data.result.length > 0) {
        response.data.result.map(item => alert(`Erro ao adicionar ao favorito: ${item.value}`));
      }
    }
  } catch (error) {
    if (Array.isArray(error.response.data.result) && error.response.data.result.length > 0) {
      error.response.data.result.map(item => alert(`Erro ao adicionar ao favorito: ${item.value}`));
    }
  }
};

const truncatedDescription = (description) => {
  const maxLength = 300;
  if (description?.length > maxLength) {
    return description.slice(0, maxLength) + '...';
  }
  return description;
};
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

.btn-adicionar {
  background-color: var(--color-link);
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
