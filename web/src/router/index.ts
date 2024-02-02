import CatalogoView from '@/views/CatalogoView.vue'
import LoginView from '@/views/LoginView.vue'
import RegistrarView from '@/views/Registrar.vue'
import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: CatalogoView
    },
    {
      path: '/catalogo',
      name: 'catalogo',
      component: () => import('../views/CatalogoView.vue')
    },
    {
      path: '/favorito',
      name: 'favorito',
      component: () => import('../views/FavoritoView.vue'),
      meta: {
        auth: true
      }
    },
    {
      path: '/entrar',
      name: 'entrar',
      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/registrar',
      name: 'registrar',
      component: () => import('../views/Registrar.vue')
    }
  ]
})

router.beforeEach((to, from, next) => {
  if(to.meta?.auth){
    const token = sessionStorage.getItem('token');
    const user = sessionStorage.getItem('user');

    if(token && user){
      next();
    }
    else{
      next({name: 'entrar'});
    }
  } else {
    next()
  }
});

export default router
