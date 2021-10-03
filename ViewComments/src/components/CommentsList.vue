<template>
    <div>
        <ul>
            
            <CommentItem 
             v-for="(comment, i) of comments"
             v-bind:comment="comment"
             v-bind:index="i"
             v-on:remove-comment="removeComment"
             />
        </ul>
    </div>
</template>

<script>
    import CommentItem from '@/components/CommentItem'
    export default {
        props: ['comments'],
        components: {
            CommentItem
        },
        methods: {
            removeComment(id) {
                this.$emit('remove-comment', id) 
            }
        }
    }
</script>

<style scoped> 
    ul {
list-style: none;
margin: 0;
padding: 0;
    }
</style>