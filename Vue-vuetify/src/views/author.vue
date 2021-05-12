<template>
  <div>
 

    <v-expansion-panels
      multiple
       focusable
    >
      <v-expansion-panel>
        <v-expansion-panel-header>作者的话：</v-expansion-panel-header>
        <v-expansion-panel-content>
        您好，尊敬的用户，很感谢你一直以来坚持使用本系统
        <br>
        信息技术大赛就在眼前，祝愿所有参赛同学能取得好成绩！
        <br>
        聊些其他的，我和你们一样，都是一名大数据学院的莘莘学子，大数据学院成立不久，我是亲眼看着它一步一步成长。从首届信息技术大赛真正刷题的人寥寥无几，到现在的全员刷题；从预计使用系统刷题人数在
        10人左右，到现在超出100人排行榜预算。从默默无闻的商学院，到现在前途无限的大数据学院；我从来没有想过会有这么多人渴望知识。
        <br>
        我们知道的，这个系统很简陋，并且也几乎没有维护。各种bug参差不齐。并不是我们无法解决，而是不想解决。作为一个突发奇想赶了两天就发布的实验品，我不认为会有几个人使用，也不会认为会被学校重视，而事实悄悄相反。
        虽然我们各自都有各自的事情，作为承诺，是时候来准备维护它了（由于个人原因，近期短时间内无法大更新）。
        </v-expansion-panel-content>
      </v-expansion-panel>

      <v-expansion-panel>
        <v-expansion-panel-header>加入我们：</v-expansion-panel-header>
        <v-expansion-panel-content>
          qq群：1104405703
          来聊聊？
        </v-expansion-panel-content>
      </v-expansion-panel>

      <v-expansion-panel>
        <v-expansion-panel-header>其他：</v-expansion-panel-header>
        <v-expansion-panel-content>
            感谢！加油！
        </v-expansion-panel-content>
      </v-expansion-panel>
    </v-expansion-panels>
  </div>
</template>
<script>
  export default {
    data: () => ({
      readonly: false,
    }),
  }
</script>