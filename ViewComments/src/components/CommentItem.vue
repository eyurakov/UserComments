<template>
    <li>
       <span v-bind:class="{done: comment.completed}">
          
           <strong>{{index + 1}}</strong>
           {{comment.userName}}: 

           {{comment.commentText}}
       </span>
        <button class="rm" v-on:click="$emit('remove-comment', comment.id)"
                >&times;</button>
    </li>
</template>

<script>
    export default {
        props: {
            comment: {
                type: Object,
                required: true
            },
            index: Number
        }
    }
</script>

<style scoped>
    li {
        border: 1px solid #ccc;
        display:flex;
        justify-content: space-between;
        padding: .5rem 2rem;
        margin-bottom: 1rem
    }
    .rm {
        background: red;
        color: #fff;
        border-radius: 50%;
        font-weight: bold;
    }
   
    input {
        margin-right: 1rem;
    }
</style>