import http from "./http-common";

class BibliocineApiService {
  login(data: object) {
    return http.post("conta/login", data);
  }

  register(data: object) {
    return http.post(`conta/register`, data);
  }

  getAll(data: string) {
    return http.get(`/catalogo?filtro=${data}`);
  }

  getFavorites(idUser: string, token: string) {
    const headers = {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    };

    return http.get(`/usuario/${idUser}`, {headers});
  } 
  
  deleteFavorite(idUser: string, obraId: string, token: string) {
    const headers = {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    };

    const params = new URLSearchParams();
    params.append('obraId', obraId);

    return http.delete(`/usuario/${idUser}?${params}`, {headers});
  }

  addFavorite(idUser: string, obraId: string, tipoObra: any, token: string) {
    const headers = {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    };

    const params = new URLSearchParams();
    params.append('obraId', obraId);
    params.append('tipoObra', tipoObra);

    return http.post(`/usuario/${idUser}?${params.toString()}`, null, {headers});
  }

  // delete(id: string) {
  //   return http.delete(`/tutorials/${id}`);
  // }

  // deleteAll() {
  //   return http.delete(`/tutorials`);
  // }

  // findByTitle(title) {
  //   return http.get(`/tutorials?title=${title}`);
  // }
}

export default new BibliocineApiService();