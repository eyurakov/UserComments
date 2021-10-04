<template>
    

    <form @submit.prevent="onSubmit">
        <div class="label_1">
            <label>User: </label>
            <br>
            <input type="text" v-model="userName" />

        </div>
        <br>
        <div class="label_2">
            <label>Comment: </label>
            <br>
            <div class="textarea">
                <textarea style="width:200px; height:100px;" type="text" v-model="commentText" />
            </div>
            

        </div>
        <div class="button">
            <button type="submit">Create</button>
        </div>

       
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
                id: 0,
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
                    //http://localhost:5001/Comments/Add?userName=${this.userName}&commentText=${this.commentText}
                    const url = 'http://localhost:5001/Comments/Add?userName=' + this.userName + '&commentText=' + this.commentText
                    fetch(url)
                        .then(response => response.json())
                        .then(json => {
                            this.comments = json
                        });

                   
                    //const requestOptions = {
                    //    method: "POST",
                    //    headers: {

                    //        'Access-Control-Allow-Origin': '*',
                    //        'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, DELETE',
                    //        'Access-Control-Allow-Headers': 'Content-Type',
                    //        'Content-Type': 'application/json',
                    //        'Accept': 'application/json'
                    //    },
                    //    mode: "no-cors",
                    //    body:newComment
                    //};

                    //fetch('http://localhost:5001/Comments/Add', requestOptions)
                    //    .then(response => {
                    //        return response.text()
                    //    })
                    //    .then((data) => {
                    //        console.log(data)
                    //    })
                    //    .catch((error) => {
                    //        console.log(error)
                    //    })

                    this.$emit('add-comment', newComment)
                }
            }
        }
    }
</script>
<style scoped>
    label_1 {
        align-content: center;
        display: flex;
    }
    label_2 {
        align-content: center;
        display: flex;
    }
    
    button {
       margin-top:20px;
    }


</style>