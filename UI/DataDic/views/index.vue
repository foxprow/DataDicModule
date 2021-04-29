<template>
    <div>
        <body-wrapper name="数据字典列表">
            <template #search>  
                <search :formData="searchForm" :supperSearch="false" @search="handleSearch" @refresh="handleRefresh">
                    <template #searchItem>
                        <el-form-item label="名称">
                            <el-input v-model="searchForm.name" size="small"></el-input>
                        </el-form-item>
                        <el-form-item label="键">
                            <el-input v-model="searchForm.key" size="small"></el-input>
                        </el-form-item>
                    </template>
                    <template #searchSupperItem>
                    </template>
                </search>
            </template #search>
            <template #btn>
                <el-button type="primary" size="small" @click="handleOpen(-1)">添加数据字典</el-button>
            </template #btn>
            <template #list>
                <el-table ref="table" v-loading="listLoading" :data="list" :border="true">
                    <el-table-column label="ID" type="index"></el-table-column>
                    <el-table-column label="名称" prop="name"></el-table-column>
                    <el-table-column label="键" prop="key"></el-table-column>
                    <el-table-column label="值" prop="value"></el-table-column>
                    <el-table-column label="备注" prop="description"></el-table-column>
                    <el-table-column label="操作">
                        <template slot-scope="scope">
                            <el-button type="text" size="small" @click="handleOpen(scope.row.id)">修改</el-button>
                            <el-button type="text" size="small" @click="handleDelete(scope.row.id)">删除</el-button>
                        </template>
                    </el-table-column>
                </el-table>
            </template #list>
            <template #pagination>
                <pagination :page.sync="page" :limit.sync="searchForm.maxResultCount" :total="total" @pagination="getList"></pagination>
            </template #pagination>
        </body-wrapper>

        <el-dialog :title="dialogForm.title" :visible.sync="dialogForm.dialogVisible" v-if="dialogForm.dialogVisible" append-to-body v-dialog-drag>
            <el-form ref="form" :model="form" :rules="rules" label-width="80px">
                <el-form-item label="名称" prop="name">
                    <el-input v-model="form.name" size="small"></el-input>
                </el-form-item>
                <el-form-item label="键" prop="key">
                    <el-input v-model="form.key" size="small"></el-input>
                </el-form-item>
                <el-form-item label="值" prop="value">
                    <el-input v-model="form.value" size="small"></el-input>
                </el-form-item>
                <el-form-item label="备注">
                    <el-input v-model="form.description" size="small"></el-input>
                </el-form-item>
            </el-form>
            <div slot="footer" class="dialog-footer">
                <el-button @click="dialogForm.dialogVisible = false">取消</el-button>
                <el-button type="primary" @click="handleSubmit">确定</el-button>
            </div>
        </el-dialog>
    </div>
</template>

<script>
import Search from '@/components/Search'
import Pagination from '@/components/Pagination'
import BodyWrapper from '@/components/BodyWrapper'
import { addDataDic, updateDataDic, deleteDataDic, getDataDicInfo, getDataDics } from '../api/datadic.js'
export default {
    name: 'DataDic',
    components: {
        Search,
        Pagination,
        BodyWrapper
    },
    data() {
        return {
            searchForm: {
                name: '',
                key: '',
                skipCount: 0,
                maxResultCount: 20
            },
            listLoading: false,
            list: [],
            total: 0,
            page: 1,
            editId: -1,
            dialogForm: {
                title: '添加数据字典',
                dialogVisible: false
            },
            form: {
                name: '',
                key: '',
                value: '',
                description: ''
            },
            rules: {
                name: [
                    { required: true, message: '名称不能为空', trigger: 'blur' },
                    { max: 30, message: '最大超度不超过30位', trigger: 'blur' }
                ],
                key: [
                    { required: true, message: '键不能为空', trigger: 'blur' },
                    { max: 30, message: '最大长度不超过30位', trigger: 'blur' }
                ],
                value: [
                    { required: true, message: '值不能为空', trigger: 'blur' }
                ]
            }
        }
    },
    created() {
        this.getList()
    },
    methods: {
        handleSearch(data) {
            this.page = 1
            this.getList()
        },
        handleRefresh() {
            this.searchForm = {
                skipCount: 0,
                maxResultCount: 20
            }
            this.page = 1
            this.getList()
        },
        getList() {
            this.listLoading = true
            this.searchForm.skipCount = (this.page - 1) * this.searchForm.maxResultCount
            getDataDics(this.searchForm).then(res => {
                this.list = res.data.items
                this.total = res.data.totalCount
                this.listLoading = false
            }).catch(error => {
                this.listLoading = false
            })
        },
        handleResetForm() {
            this.form = {
                name: '',
                key: '',
                value: '',
                description: ''
            }
        },
        handleOpen(id) {
            this.editId = id
            this.handleResetForm()
            if (id === -1) {
                this.dialogForm.title = '添加数据字典'
                this.dialogForm.dialogVisible = true
            } else {
                getDataDicInfo(id).then(res => {
                    this.form = res.data
                    this.dialogForm.title = '修改数据字典'
                    this.dialogForm.dialogVisible = true
                })
            }
        },
        handleDelete(id) {
            this.$confirm('确定要删除此数据字典项?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                deleteDataDic(id).then(res => {
                    this.$message.success('字典项删除成功')
                    this.getList()
                })
            })
        },
        handleSubmit() {
            this.$refs.form.validate(valid => {
                if (!valid) return
                if (this.editId === -1) {
                    addDataDic(this.form).then(res => {
                        this.$message.success('数据字典项添加成功')
                        this.dialogForm.dialogVisible = false
                        this.getList()
                    })
                } else {
                    updateDataDic(this.editId, this.form).then(res => {
                        this.$message.success('数据字典项修改成功')
                        this.dialogForm.dialogVisible = false
                        this.getList()
                    })
                }
            })
        }
    },
}
</script>

<style>

</style>