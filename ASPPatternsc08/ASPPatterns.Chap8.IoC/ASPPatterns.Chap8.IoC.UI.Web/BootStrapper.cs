using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using ASPPatterns.Chap8.IoC.Model.Payment;
using ASPPatterns.Chap8.IoC.Model.Despatch;

namespace ASPPatterns.Chap8.IoC.UI.Web
{
    public class BootStrapper
    {
        /// <summary>
        /// 配置SM相关的实例化对象的类型
        /// </summary>
        public static void ConfigureStructureMap()
        {
            // Initialize the registry
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ModelRegistry>();

            });
        }

        /// <summary>
        /// A Registry class provides methods and grammars for configuring a Container or ObjectFactory. Using a Registry subclass is the recommended way of configuring   a StructureMap Container.
        /// 一个注册表类提供了方法和配置一个容器或ObjectFactory语法。推荐使用一个注册表子类的方式配置StructureMap容器。
        /// </summary>
        public class ModelRegistry : Registry
        {
            public ModelRegistry()
            {
                
                ForRequestedType<IPaymentGateway>()//表达式构建器PluginType包括用于定义政策范围,默认实例,拦截。BuildInstancesOf()和ForRequestedType()是同义词
                    .TheDefault                    //这个PluginType定义默认实例
                    .Is                            //给你完全访问所有的不同的方法来指定一个“实例”                            
                    .OfConcreteType<PaymentGateway>();  //构建的实例构造函数和赋值参数。StructureMap.Pipeline.SmartInstance ' 1的定义开始

                ForRequestedType<IPaymentMerchant>().TheDefault.Is.OfConcreteType<StreamLinePaymentMerchant>();
                ForRequestedType<IDespatchService>().TheDefault.Is.OfConcreteType<DespatchService>();
                ForRequestedType<ICourier>().TheDefault.Is.OfConcreteType<FedExCourier>();
            }

        }

    }
}
