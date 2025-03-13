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
class CreateSubscriptionExample
{
    fun createSubscription()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val statements1 = StatementPost(
            effect = StatementPost.Effect.allow,
            resources = listOf (
                "proj/*:env/*:flag/*;testing-tag",
            ),
            actions = listOf (
                "*",
            ),
        )

        val statements = arrayListOf<StatementPost>(
            statements1,
        )

        val subscriptionPost = SubscriptionPost(
            name = "Example audit log subscription.",
            config = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "optional": "an optional property",
                    "required": "the required property",
                    "url": "https://example.com"
                }
            """)!!,
            on = false,
            tags = listOf (
                "testing-tag",
            ),
            statements = statements,
        )

        try
        {
            val response = IntegrationAuditLogSubscriptionsApi().createSubscription(
                integrationKey = "integrationKey_string",
                subscriptionPost = subscriptionPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IntegrationAuditLogSubscriptionsApi#createSubscription")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IntegrationAuditLogSubscriptionsApi#createSubscription")
            e.printStackTrace()
        }
    }
}
