Настройка проекта

Открыть PowerShell консоль
Установить node модули зависимостей

```bash
npm i
```

Запуск в режиме разработки

```bash
npm run dev
```

Сгенерировать проект в продовую версию для развертки без ноды(предположитьельно)

```bash
npm run generate
```

Запустить проект в продовом виде

```bash
npm run preview
```

Сочетание ctrl+C в терминале запросит огстановку запущенного проекта

Пояснения по структуре проекта
"~" - базовый каталог проекта
По умолчанию переход на "/" перенаправит на "/login"
Все запросы делаются с помощью самописного псевдоплагина "~/plugins/api.ts"
Если вернулсь ошибка происходит выход.

Действия Login и Logout вынесены в компонент хранилища. "~/store/auth.store.ts"
Наполнение меню происходит только при логине(возможно логику нужно пересмотреть) и записывается в хранилище "~/store/menu.store.ts" (localStorage что-бы сохранялось при перезагрузке браузера)
Архитектура Nuxt3 позволяет для прегенрации использовать физические страницы "~/pages/*"
Внутри страниц делаем импорт нужного компонента. Используем TypeScript, во всех элементах используем раздел скриптов setup. Все компоненты это шаблоны(template)

```html
<template>
  <Crud />
</template>

<script lang="ts" setup>
import Crud from '~/components/Crud/User.vue';
</script>
```

Рассмотрим компонент "~/components/Crud/User.vue"
Это шаблон. В котором используются множество других шаблонов. Практически базовый шаблон это VCard
(https://dev.vuetifyjs.com/en/components/cards/) - описание и презентация шаблона
(https://dev.vuetifyjs.com/en/api/v-card/) - описание api данного шаблона

Внутри есть комонент VRow(строки) и VCol(столбцы) в столбцах поле для поиска, кнопка для поиска, кнопка для вызова формы добавления.
Ниже используется компонент VDataTable
```html
<VDataTable
    :show-select="selectMulti"
    :headers="headers"
    :items="useCrud.items.value"
    :footer-props="{
        'Элементов на странице': 10,
    }"
    :options.sync="useCrud.pagination"
    :server-items-length="useCrud.total"
    :loading="useCrud.loading.value"
    :item-key="itemKey">
</VDataTable>
```

В компонент переданы определенные свойства.
Что-бы получить значение свойства из кода свойство описывается через ":" - ":headers="headers""
Какие именно свойства компонент/шаблон ждет можно узнать в api или презентации(см. выше)

Смотрим ниже.
Раздел скрипта setup.
Тут происходит первоначальная настройка текущего копонента (тут описывается компонент "~/components/Crud/User.vue")
Для начала ипортируем все необходимые компоненты которые будет использовать компонент

```ts
import mixinPropsCrud from '~/composables/mixinPropsCrud'
import mixinUseCrud from '~/composables/mixinUseCrud'
import { ref } from 'vue'
import MyAlert from '~/components/Control/MyAlert.vue'
import DialogConfirm from '~/components/Dialog/DialogConfirm.vue'
import helpers from '~/utils/helpers'
import { fetchData } from '~/plugins/api'
import Form from '~/components/Form/User.vue'
```

Если в компоненте нужно принять какие-то свойства то необходимо объявить приходящие "props". В коде свойства описываются в нотации lowCamelNotation. В передаче в копонент в html нет передачи в этой нотации. В html доступна только cebab-notation - перевод происходит автоматом.

```ts
const mixinPropsCrud = {
visible: {
    type: Boolean,
    default: true,
  },
  select: {
    type: Boolean,
    default: true,
  },
  selectMulti: {
    type: Boolean,
    default: false,
  },
  disableAutoLoad: {
    type: Boolean,
    default: true,
  },
}

var props = defineProps(mixinPropsCrud)
```

```html
<User visible="true" :select-multi="valueTrue" />
```

Если внутри компонента какие-то переменные компонента должны реагировать на изменения то данные переменные должны быть обернуты в объект ref.

```ts
const headers = ref([
  { title: 'ID пользователя', key: itemKey, align: 'end', sortable: true, },
  { title: 'ФИО', key: 'name', align: 'start', sortable: true, },
  { title: 'E-mail', key: 'email', align: 'start', sortable: true, },
  { title: 'Роль', key: 'role.name', align: 'start', sortable: true, },
  { title: 'Активация', key: 'isActive', align: 'center', sortable: false, }
])
```

Если нужно что бы при создании компонента должно что-то произойти то используем в скрипте хук(перехват события из потока состояния приложения/коипонента)
В данном случае в переменную кладем функцию и уже переменную используем в хуке.

```ts
const anyFunction = () => { }

onMounted(anyFunction)
```

В копоненте делаем запрос используя "fetchData" из "~/plugins/api".
Метод принимает часть адреса для запроса. И запрос. Для упрощения сделана функция создания запроса "BuildQuery".
BuildQuery: (queryType: HttpQueryType, postBody?: any) => IHttpQuery
queryType - HttpQueryType - enum текстовых полей представляют собой используемые приложением типы запросов "POST"/"GET"/"PUT"/"DELETE"
postBody - не обязательный объект который будет отпрален бэку

Для вызова формы используются копоненты из "~/components/Form/*"
Вызов формы происходит сменой состояния булевой перменной "useCrud.isForm.value"

```html
<Form
    v-model:isActive="useCrud.isForm.value"
    v-bind:title-suffix="titleSuffixForm"
    :is-new="useCrud.isNew.value"
    :edited-item="useCrud.editedItem"
    :api-address="apiAddress"
/>
```

Внутри компонента конкретной формы используем базовый компонент "~/components/Form/Form". Он реализует базовый VCard и VDialog что-бы меньше захламлять основые компоненты форм.
Компонент реализует именованный слот "#fields" для использования в качестве базового компонента.

Сам компонент реализует только вводные поля, их обработку и методы сохранения.

Вводные поля так же в основной массе выбираются из документации к vuetify.
"https://dev.vuetifyjs.com/en/components/autocompletes/" - первый из импутов которые описаны во framework`е.

Мне раньше сложно было понять как работают правила проверки полей.
Импортируем нужные правила из "~/utils/validators"
Используем конкретные правила { requiredRule, lengthRule, emailRule }
Для написания своих правил нужно реализовать функцию (*): (boolean|string) => { }
Какая-то функция с любыми входными данными возвращающее либо булевое (в основном true) либо текст, который будет выведен в сообщении об ошибке в поле.

Для возвращения какого-либо события из дочернего копонента необходимо объявить возможные события генерируемые компонентом.

```ts
const emit = defineEmits(['update:isActive'])

const close = () => {
  emit('update:isActive', false)
}
```

