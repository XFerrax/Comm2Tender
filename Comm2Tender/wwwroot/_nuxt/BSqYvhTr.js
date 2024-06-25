import{r as i,d as x,t as m,L as y,ay as b,A as a,z as e,az as k,B as u,ab as B,ac as C,U as p,T as f,a1 as h,aA as S,a9 as F,aa as A,y as V,aB as T,aC as w,a2 as _,a8 as N,v,S as D}from"./01VIqO6s.js";const L={visible:{type:Boolean,default:!0},select:{type:Boolean,default:!0},selectMulti:{type:Boolean,default:!1},disableAutoLoad:{type:Boolean,default:!0},disableFilter:{type:Boolean,default:!0},hideFilter:{type:Boolean,default:!1},hideSearch:{type:Boolean,default:!1},addNow:{type:Boolean,default:!0},readonly:{type:Boolean,default:!1},actual:{type:Boolean,default:!0}};function U(){const l=function(o,d){this.editedItem=JSON.parse(JSON.stringify(o)),d&&d()},t=function(o){this.mixinSetCurrent(o),this.menu.value=!0},n=function(o){this.isNew.value=!1,this.mixinSetCurrent(o),this.isForm.value=!0},s=function(o){this.mixinSetCurrent(o),this.isDialogConfirm.value=!0},r=function(){clearTimeout(this.searchTimeout.value),this.loading.value=!0},c=function(o){this.loading.value=!1};return{search:i(""),loading:i(!1),selected:i([]),items:i([]),pagination:i({}),total:i(0),editedItem:i({}),menu:i(!1),isNew:i(!1),isForm:i(!1),isDialogConfirm:i(!1),searchTimeout:i(void 0),mixinSetCurrent:l,mixinMenuItem:t,mixinEditItem:n,mixinDeleteItem:s,mixinBeforeRequest:r,mixinAfterRequest:c}}const $=x({__name:"MyAlert",props:{visible:{type:Boolean,default:!0},dark:{type:Boolean,default:!1},outlined:{type:Boolean,default:!1},color:{type:String,default:"primary"},icon:{type:String,default:void 0},text:{type:String,required:!0}},setup(l){return(t,n)=>(m(),y(b,{value:l.visible,color:l.color,dark:l.dark,icon:l.icon,outlined:l.outlined,dense:"",text:l.text,class:"ma-0 text-left"},null,8,["value","color","dark","icon","outlined","text"]))}}),M=x({__name:"DialogConfirm",props:{isOpen:{type:Boolean,required:!0}},emits:["confirm","cancel"],setup(l,{emit:t}){const n=l,s=t,r=()=>{s("confirm")},c=()=>{s("cancel")};return(o,d)=>(m(),y(S,{modelValue:n.isOpen,"onUpdate:modelValue":d[0]||(d[0]=g=>n.isOpen=g),"max-width":"400"},{default:a(()=>[e(h,null,{default:a(()=>[e(k,{class:"text-h5"},{default:a(()=>[u("Подтверждение")]),_:1}),e(B,null,{default:a(()=>[u("Вы уверены, что хотите удалить?")]),_:1}),e(C,null,{default:a(()=>[e(p),e(f,{color:"primary",text:"",onClick:r},{default:a(()=>[u("Да")]),_:1}),e(f,{color:"secondary",text:"",onClick:c},{default:a(()=>[u("Нет")]),_:1})]),_:1})]),_:1})]),_:1},8,["modelValue"]))}}),I={isActive:Boolean,saveFunc:Function,closeFunc:Function,disableActions:Boolean,title:String,editedItem:Object,isNew:Boolean,titleSuffix:String,apiAddress:String},j=x({__name:"Form",props:I,setup(l){const t=l,n=()=>t.title&&t.title!=""?t.title:t.titleSuffix&&t.titleSuffix!=""?(t.isNew?"Добавление":"Редактирование")+" "+t.titleSuffix:"";return(s,r)=>(m(),y(S,{modelValue:t.isActive,"onUpdate:modelValue":r[0]||(r[0]=c=>t.isActive=c),transition:"dialog-top-transition","max-width":"800"},{default:a(()=>[e(N,{ref:"form","fast-fail":""},{default:a(()=>[e(h,{class:"elevation-10"},{default:a(()=>[e(F,{color:"primary",class:"flex-grow-0"},{default:a(()=>[e(A,null,{default:a(()=>[u(V(n()),1)]),_:1}),e(p),e(T,null,{default:a(()=>[e(f,{density:"comfortable",variant:"tonal",onClick:t.closeFunc,icon:"mdi-close"},null,8,["onClick"])]),_:1})]),_:1}),e(B,null,{default:a(()=>[w(s.$slots,"fields")]),_:3}),e(C,{class:"pa-4"},{default:a(()=>[e(_,{wrap:""},{default:a(()=>[e(_,{"justify-center":""},{default:a(()=>[e(p),e(f,{color:"primary",variant:"tonal",onClick:t.saveFunc,text:"Сохранить"},null,8,["onClick"]),e(f,{class:"ml-3",disabled:s.disableActions,onClick:t.closeFunc,variant:"tonal",text:"Отмена"},null,8,["disabled","onClick"]),e(p)]),_:1})]),_:1})]),_:1})]),_:3})]),_:3},512)]),_:3},8,["modelValue"]))}}),q={key:0,style:{color:"red"}},z={__name:"FormLabel",props:{label:{type:String,default:""},required:{type:Boolean,default:!1}},setup(l){return(t,n)=>(m(),v("div",null,[u(V(l.label)+" ",1),l.required?(m(),v("strong",q,"*")):D("",!0)]))}};export{z as _,j as a,L as b,U as c,$ as d,M as e,I as m};