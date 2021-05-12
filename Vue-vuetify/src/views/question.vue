<template >
  <v-app class="grey lighten-5">
    <v-container>
      <div class="text-h5">
        {{ questionData.id }}.题目:{{ questionData.subject }}
      </div>
      <v-subheader
        >类型：{{ questionData.type }}<v-breadcrumbs></v-breadcrumbs>难度：{{
          questionData.difficulty
        }}</v-subheader
      >
      <v-divider></v-divider>
      <v-btn class="ma-2" outlined color="indigo" @click="sentAnswer('A')">
        A： {{ questionData.question_a }}
      </v-btn>
      <br />
      <v-btn class="ma-2" outlined color="indigo" @click="sentAnswer('B')">
        B： {{ questionData.question_b }}
      </v-btn>
      <br />
      <v-btn class="ma-2" outlined color="indigo" @click="sentAnswer('C')">
        C： {{ questionData.question_c }}
      </v-btn>
      <br />
      <v-btn class="ma-2" outlined color="indigo" @click="sentAnswer('D')">
        D： {{ questionData.question_d }}
      </v-btn>
      <div class="text-h6 red--text">{{ msg }}</div>
      <v-btn depressed color="primary" class="ma-2" @click="lastAnswer"> 上一题 </v-btn>
    </v-container>
  </v-app>
</template>
<script>
import questionApi from "@/api/questionApi";
export default {
  data: () => ({
    questionData: {},
    msg: "",
  }),
  created() {
    this.initialize();
  },
  methods: {
    lastAnswer() {
      questionApi.last().then((resp) => {
        this.msg = "";
        this.initialize();
      });
    },
    sentAnswer(answer) {
      questionApi.effectiveness(answer).then((resp) => {
        if (resp.data) {
          this.msg = "";
          this.initialize();
        } else {
          this.msg = `选项${answer}错误，请重新选择。`;
        }
      });
    },
    initialize() {
      questionApi.getQuestion().then((resp) => {
        const response = resp.data;
        this.questionData = response;
      });
    },
  },
};
</script>