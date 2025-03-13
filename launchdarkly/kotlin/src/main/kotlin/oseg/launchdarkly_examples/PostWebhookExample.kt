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
class PostWebhookExample
{
    fun postWebhook()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val statements1 = StatementPost(
            effect = StatementPost.Effect.allow,
            resources = listOf (
                "proj/test",
            ),
            actions = listOf (
                "*",
            ),
        )

        val statements = arrayListOf<StatementPost>(
            statements1,
        )

        val webhookPost = WebhookPost(
            url = "https://example.com",
            sign = false,
            on = true,
            name = "apidocs test webhook",
            tags = listOf (
                "example-tag",
            ),
            statements = statements,
        )

        try
        {
            val response = WebhooksApi().postWebhook(
                webhookPost = webhookPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling WebhooksApi#postWebhook")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling WebhooksApi#postWebhook")
            e.printStackTrace()
        }
    }
}
