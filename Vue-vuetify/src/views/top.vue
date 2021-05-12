<template>
  <v-card>
    <v-data-table
      :headers="headers"
      :items="desserts"
      sort-by="calories"
      class="elevation-1"
      item-key="Id"

      :search="search"
    >
      <template v-slot:top>
        <!-- 搜索框 -->
        <v-toolbar flat>
          <v-spacer></v-spacer>
          <v-text-field
            v-model="search"
            append-icon="mdi-magnify"
            label="搜索"
            single-line
            hide-details
            class="mx-4"
          ></v-text-field>
        </v-toolbar>
      </template>


      <!-- 初始化 -->
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize"> 刷新 </v-btn>
      </template>
    </v-data-table>


  </v-card>
</template>
<script>
import IntegralApi from "@/api/IntegralApi"
export default {
  data: () => ({
    page: 1,
    selected: [],
    search: "",
    headers: [
      {
        text: "编号",
        align: "start",
        value: "id",
      },
      { text: "用户", value: "user_name", sortable: false },
      { text: "得分", value: "integral", sortable: true }
      
    ],
    desserts: [],
  }),
  created() {
    this.initialize();
  },

  methods: {
    initialize() {
      IntegralApi.GetTop(100,1).then((resp) => {
        const response=resp.data
        this.desserts = response;
      });
    },
  },
};
</script>
