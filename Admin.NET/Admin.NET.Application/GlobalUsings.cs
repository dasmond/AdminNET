// ��ʡ��ѧԺ���֤
//
// ��Ȩ���� (c) 2021-2023 zuohuaijun�������Ƽ���������޹�˾  ��ϵ�绰/΢�ţ�18020030720  QQ��515096995
//
// �ش���������ñ�������κ����Դ��������Ȩ���������������������������и�������Ҫ���ֵ�����б������������Ȩ�����ͱ����������
//
// �������ԭ�����ṩ�����ṩ�κ���ʽ����ʾ��ʾ�ı�֤�������������ڶ������ԡ������Ժͷ���Ȩ�ı�֤��
// ���κ�����£����߻��Ȩ�����˾������κ����⡢�𺦻��������θ������������ͬ����Ȩ��������ʽ����ģ����������ʹ�û����������йء�

global using Admin.NET.Core.Service;
global using Furion;
global using Furion.ClayObject;
global using Furion.ConfigurableOptions;
global using Furion.DatabaseAccessor;
global using Furion.DataEncryption;
global using Furion.DataValidation;
global using Furion.DependencyInjection;
global using Furion.DynamicApiController;
global using Furion.EventBus;
global using Furion.FriendlyException;
global using Furion.JsonSerialization;
global using Furion.Logging;
global using Furion.RemoteRequest.Extensions;
global using Furion.Schedule;
global using Furion.UnifyResult;
global using Furion.ViewEngine;
global using Magicodes.ExporterAndImporter.Core;
global using Magicodes.ExporterAndImporter.Excel;
global using Mapster;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using NewLife.Caching;
global using Newtonsoft.Json;
global using SKIT.FlurlHttpClient;
global using SKIT.FlurlHttpClient.Wechat.Api;
global using SKIT.FlurlHttpClient.Wechat.Api.Models;
global using SKIT.FlurlHttpClient.Wechat.TenpayV3;
global using SKIT.FlurlHttpClient.Wechat.TenpayV3.Events;
global using SKIT.FlurlHttpClient.Wechat.TenpayV3.Models;
global using SKIT.FlurlHttpClient.Wechat.TenpayV3.Settings;
global using SqlSugar;
global using System.Collections;
global using System.Collections.Concurrent;
global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations;
global using System.Data;
global using System.Diagnostics;
global using System.Linq.Dynamic.Core;
//global using Admin.NET.Entity;
global using System.Linq.Expressions;
global using System.Reflection;
global using System.Runtime.InteropServices;
global using System.Text;
global using System.Text.RegularExpressions;
global using System.Web;
global using UAParser;
global using Yitter.IdGenerator;
global using Admin.NET.Core;
global using Admin.NET.Application.Entity;
global using System.Threading.Tasks;
global using System;
global using System.Collections.Generic;