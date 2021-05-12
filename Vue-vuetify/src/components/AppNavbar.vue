<template >
  <v-card class="mx-auto deep-purple" height="100%" width="100%">
    <!-- deep-purple -->

    <v-list-item>
      <v-list-item-content>
        <v-list-item-title class="title"> 题库管理系统 </v-list-item-title>
        <v-list-item-subtitle> 测试版 </v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>

    <v-divider></v-divider>

    <v-list>
      <v-list-item v-for="item in items" :key="item.title" :to="item.router">
        <v-list-item-icon>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>

    </v-list>
  </v-card>
</template>
<script>
export default {
  data() {
    return {
      actions: [],
      cruds: [],
      items: [
        { title: "主页", icon: "mdi-view-dashboard", router: "/index" },
        { title: "题库搜索", icon: "mdi-account-box", router: "/search" },
        { title: "排行榜", icon: "mdi-gavel", router: "/top" },
        { title: "开始刷题", icon: "mdi-lock", router: "/question" },
        { title: "作者的话", icon: "mdi-lock", router: "/author" }
      ],
    };
  }
};
</script>