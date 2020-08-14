import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import CreateLeague from '@/views/CreateLeague.vue'
import FindCourses from '@/views/FindCourses.vue'
import Leaderboard from '@/views/Leaderboard.vue'
import PostScores from '@/views/PostScores.vue'
import Leagues from '@/views/Leagues.vue'
import Users from '@/views/Users.vue'
import League from '@/views/League.vue'
import AddCourse from '@/views/AddCourse.vue'
import JoinLeague from '@/views/JoinLeague.vue'
import SendInvite from '@/views/SendInvite.vue'



Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  props: ['id'],
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/create",
      name: "create",
      component: CreateLeague,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/locate",
      name: "locate",
      component: FindCourses,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/leaderboard",
      name: "leaderboard",
      component: Leaderboard,
      meta:{
        requiresAuth: true
      }
    },
    {
      path: "/post",
      name: "post",
      component: PostScores,
      meta:{
        requiresAuth: true
      }
    },
      {
        path: "/leagues",
        name: "leagues",
        component: Leagues,
        meta:{
          requiresAuth: true
        }
      },
       {
         path: "/user/:id",
         name: "user/id",
         component: Users,
         meta:{
           requiresAuth: true
         }
       },
       {
        path: "/leagues/:username",
        name: "leagueByUsername",
        props: true,
        component: League,
        meta:{
          requiresAuth: true
        }
      },
       {
         path: "/new",
         name: "addcourse",
         component: AddCourse,
         meta:{
           requiresAuth: true
         }
       },
       {
        path: "/",
        name: "sendinvite",
        component: SendInvite,
        meta:{
          requiresAuth: true
        }},
        {
         path: "/join",
         name: "join",
         component: JoinLeague,
         meta:{
           requiresAuth: true
         }},
      ]
    
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
