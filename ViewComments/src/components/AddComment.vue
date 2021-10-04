<template>


    <form @submit.prevent="onSubmit">
        <div class="label_1">
            <label>User: </label>
            <br>
            <input type="text" v-model="userName" title="Enter name of USer"/>

        </div>
        <br>
        <div class="label_2">
            <label>Comment: </label>
            <br>
            <div class="textarea">
                <textarea style="width:200px; height:100px;" type="text" v-model="commentText" />
            </div>


        </div>

        <div v-if="errors.length > 0">
            <ul>
                <li v-for="error in errors" style="color:red">{{error}}</li>
            </ul>
        </div>
        <div class="button">
            <button type="submit">Create</button>
        </div>


    </form>
</template>
<script>
    headers: {
        'Access-Control-Allow-Origin'
    }
    import { validationMixin } from 'vuelidate'
    export default {
        mixins: [validationMixin],
        name: 'AddComment',
        data() {
            return {
                id: 0,
                userName: '',
                commentText: '',
                errors: []
            }
        },
        validations: {
            userName:
            {
                simpleValidator(value) {
                    console.log(value)
                    return value.length > 2
                }
            },
            commentText:
            {
                simpleValidator(value) {
                    console.log(value)
                    return value.length > 14
                }
            }
        },
        methods: {
            onSubmit() {

                this.errors = [];

                if (this.userName.trim()=='')
                    this.errors.push("User field is required");

                if (this.commentText.trim()=='')
                    this.errors.push("Comment field is required");

                if (this.userName.trim().length < 3)
                    this.errors.push("User must be more then 3 characters");

                if (this.commentText.trim().length<15)
                    this.errors.push("Comment must be more then 15 characters");


                if (this.errors.length==0) {
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
        margin-top: 20px;
    }
    li {
        list-style-type: none;
        font-size: 10px;
    }
</style>