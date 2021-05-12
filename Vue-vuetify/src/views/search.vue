<template>
  <v-card>
    <v-data-table
      :headers="headers"
      :items="desserts"
      sort-by="calories"
      class="elevation-1"
      item-key="id"
      show-select
      v-model="selected"
      :options.sync="pagination"
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

          <!-- 详情提示框 -->
          <v-dialog v-model="dialog" max-width="500px">
            <v-card>
              <v-card-title>
                <span class="headline">数据详情</span>
              </v-card-title>

              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12">
                      <v-text-field
                        disabled
                        v-model="editedItem.subject"
                        label="题目"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field
                        disabled
                        v-model="editedItem.question_a"
                        label="A选项"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field
                        disabled
                        v-model="editedItem.question_b"
                        label="B选项"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field
                        disabled
                        v-model="editedItem.question_c"
                        label="C选项"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field
                        disabled
                        v-model="editedItem.question_d"
                        label="D选项"
                      ></v-text-field>
                    </v-col>
                     <v-col cols="12">
                      <v-h4>正确选项：{{editedItem.answer}}</v-h4>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>

      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)"> mdi-pencil </v-icon>
      </template>

      <!-- 初始化 -->
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize"> 刷新 </v-btn>
      </template>
    </v-data-table>

    <template>
      <v-pagination
        circle
        v-model="pageIndex"
        :length="lenData"
        :total-visible="7"
        prev-icon="mdi-menu-left"
        next-icon="mdi-menu-right"
      ></v-pagination>
    </template>
  </v-card>
</template>
<script>
import questionApi from "@/api/questionApi";
export default {
  data: () => ({
    pagination: { page: 1, itemsPerPage: 10 },
    pageIndex: 1,
    selected: [],
    search: "",
    dialog: false,
    totol: 0,
    headers: [
      {
        text: "编号",
        align: "start",
        value: "id",
      },
      { text: "题目", value: "subject", sortable: false },
      { text: "类型", value: "type", sortable: false },
      { text: "难度", value: "difficulty", sortable: false },
      { text: "详情", value: "actions", sortable: false }
    ],
    desserts: [],
    editedItem: {
      subject: "",
      question_a: "",
      question_d: "",
      question_c: "",
      question_e: "",
      answer:""
    },
  }),
  watch: {
    search() {
      this.initialize();
    },
    pageIndex: {
      handler() {
        this.initialize();
      },
    },
    pagination: {
      handler() {
        this.initialize();
      },
      deep: true,
    },
  },
  computed: {
    lenData() {
      return Math.floor(this.totol / this.pagination.itemsPerPage) + 1;
    },
  },
  // created() {

  // },

  methods: {
    initialize() {
      questionApi
        .getAll(this.pagination.itemsPerPage, this.pageIndex, this.search)
        .then((resp) => {
          if (resp.status) {
            const response = resp.data.mydata;
            this.totol = resp.data.totol;
            this.desserts = response;
          }
        });
    },
    // 添加和修改都打开同一个编辑框
    editItem(item) {
      this.editedIndex = this.desserts.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },
    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
  },
};
</script>
