package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class CreateIntegrationConfigurationExample
{
    fun createIntegrationConfiguration()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val capabilityConfigAuditLogEventsHookStatements1 = StatementPost(
            effect = StatementPost.Effect.allow,
            resources = listOf (
                "proj/*:env/*:flag/*;testing-tag",
            ),
            notResources = listOf (),
            actions = listOf (
                "*",
            ),
            notActions = listOf (),
        )

        val capabilityConfigAuditLogEventsHookStatements = arrayListOf<StatementPost>(
            capabilityConfigAuditLogEventsHookStatements1,
        )

        val capabilityConfigApprovalsAdditionalFormVariables = arrayListOf<FormVariable>()

        val capabilityConfigApprovals = ApprovalsCapabilityConfig(
            additionalFormVariables = capabilityConfigApprovalsAdditionalFormVariables,
        )

        val capabilityConfigAuditLogEventsHook = AuditLogEventsHookCapabilityConfigPost(
            statements = capabilityConfigAuditLogEventsHookStatements,
        )

        val capabilityConfig = CapabilityConfigPost(
            approvals = capabilityConfigApprovals,
            auditLogEventsHook = capabilityConfigAuditLogEventsHook,
        )

        val integrationConfigurationPost = IntegrationConfigurationPost(
            name = "Example integration configuration",
            configValues = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "optional": "an optional property",
                    "required": "the required property",
                    "url": "https://example.com"
                }
            """)!!,
            enabled = true,
            tags = listOf (
                "ops",
            ),
            capabilityConfig = capabilityConfig,
        )

        try
        {
            val response = IntegrationsBetaApi().createIntegrationConfiguration(
                integrationKey = null,
                integrationConfigurationPost = integrationConfigurationPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IntegrationsBetaApi#createIntegrationConfiguration")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IntegrationsBetaApi#createIntegrationConfiguration")
            e.printStackTrace()
        }
    }
}
