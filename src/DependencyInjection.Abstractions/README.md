### iForeach.Extensions.DependencyInjection.Abstractions

### 模块功能
扩展 [Micorsoft.Extensions.DependencyInjection](https://github.com/aspnet/Extensions/tree/9bc79b2f25a3724376d7af19617c33749a30ea3a)：
1. 支持对服务类型用 <font color="red">**标识名称**</font> 和 <font color="red">**标识键**</font> 标识
2. 支持按 <font color="red">**标识名称**</font> 或 <font color="red">**标识键**</font> 获取服务

#### 代码参考
* github: [blqw.DI：NamedService](https://github.com/blqw/blqw.DI/tree/master/src/blqw.DI.NamedService)

### 基础类库
* netstandard：>= 2.1.0-prerelease.19126.1

### 第三方模块依赖
* Micorsoft.Extensions.DependencyInjection：
   * github: https://github.com/aspnet/Extensions/tree/9bc79b2f25a3724376d7af19617c33749a30ea3a
   * nuget: https://www.nuget.org/packages/Micorsoft.Extensions.DependencyInjection
   * version: >= 3.0.0-preview5.19227.9

### TODO List
- [ ] _**version 1.0**_
  > 目标：
    > * netstandard 2.1
    > * Microsoft.Extensions.DependencyInjection 3.0
  - [ ] **netstandard** (_version 2.1_)
    - [x] 基于 _2.1.0-prerelease.19126.1_ 实现
    - [ ] 升级到 _2.1_ 发行版
  - [ ] **Microsoft.Extensions.DependencyInjection** _version 3.0_
    - [x] 基于 _3.0.0-preview5.19227.9_ 实现
    - [ ] 升级到 _3.0_ 发行版

### Version List
> ##### 2019-05-11
1. 完成自 [blqw.DI：NamedService](https://github.com/blqw/blqw.DI/tree/master/src/blqw.DI.NamedService) 的代码转换，实现 _**NamedService**_ 支持
2. 实现 _**KeyedService**_ 的支持
