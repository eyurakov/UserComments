<template>
    <form @submit.prevent="onSubmit">
        <input type="text" v-model="userName" />
        <input type="text" v-model="commentText" />
        <button type="submit">Create</button>
    </form>
</template>
<script>
    import axios from 'axios'
    headers: {
        'Access-Control-Allow-Origin'
    }

    export default {
        name: 'AddComment',
        data() {
            return {
                userName: '',
                commentText: ''
            }

        },

        methods: {

            onSubmit() {

                if (this.commentText.trim(), this.userName.trim()) {
                    const newComment = {
                        id: 0,
                        userName: this.userName,
                        commentText: this.commentText,
                        completed: false
                    }

                    let headers = {
                        
                        'Access-Control-Allow-Origin': '*',
                        //'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, DELETE',
                        //'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
                        'Content-Type': 'application/json'
                    };

                    
                    //axios.post('http://localhost:5001/Comments/Add', newComment, {headers})
                    const requestOptions = {
                        method: "POST",
                        headers:  headers ,
                        mode: "no-cors",
                       body: JSON.stringify(newComment)
                    };
                    fetch('http://localhost:5001/Comments/Add', requestOptions)
                    .then((response) => {
                            return response.json();
                        })
                        .then((data) => {
                            console.log(data);
                        });


                    //fetch('https://localhost:5001/Comments/Add',
                    //    {
                    //        method: 'POST',
                    //        body: JSON.stringify(newComment)
                    //        //,
                    //        //headers: {
                    //        //    "Accept": "application/json",
                    //        //    "Access-Control-Allow-Origin": "*",
                    //        //    "X-Requested-With": "XMLHttpRequest",
                    //        //    "Access-Control-Allow-Methods": "GET,POST,PUT,DELETE,OPTIONS",
                    //        //    "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With",
                    //        //    'Content-Type': 'application/json'
                    //        //}
                    //    })
                    //    .then((response) => {
                    //        return response.json();
                    //    })
                    //    .then((data) => {
                    //        console.log(data);
                    //    });

                    this.$emit('add-comment', newComment)
                }
            }
        }
    }
</script>
<style scoped>
    form {
        display: flex;
    }

    input {
        width: 400px;
    }
</style>