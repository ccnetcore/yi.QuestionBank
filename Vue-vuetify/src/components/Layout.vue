<template>
  <div>
    <v-app id="inspire" >
      <v-navigation-drawer v-model="drawer" class=" deep-purple" dark app>
        <app-navbar></app-navbar>
        <template v-slot:append>
          <div class="pa-2">
            <v-btn block @click="off()"> 退出 </v-btn>
          </div>
        </template>
      </v-navigation-drawer>

      <v-app-bar app dark class="deep-purple accent-2"  >
        <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
        <app-header></app-header>
      </v-app-bar>

      <v-main class="grey lighten-5">
        <v-container >
          <app-main ></app-main>
        </v-container>
      </v-main>
    </v-app>
  </div>
</template>
<script>
import AppHeader from "./AppHeader.vue";
import AppNavbar from "./AppNavbar.vue";
import AppMain from "./AppMain.vue";
import accountApi from "@/api/accountApi";
export default {
  data() {
    return {
      drawer: null,
    };
  },
  methods: {
    off() {
      accountApi.logOff().then((resp) => {
       if (resp.status) {
          localStorage.clear();
        this.$router.push("/login");
       }
      });
    },
  },
  components: {
    AppHeader,
    AppNavbar,
    AppMain,
  },
};
</script>
